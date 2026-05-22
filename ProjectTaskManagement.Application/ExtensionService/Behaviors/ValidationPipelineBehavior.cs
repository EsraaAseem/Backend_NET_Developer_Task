using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.ExtensionService.Behaviors
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : GenericResponse<string>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                return (TResponse)CreateErrorResponse(errorsDictionary);
            }

            return await next();
        }

        private GenericResponse<string> CreateErrorResponse(Dictionary<string, string[]> errors)
        {
            return  GenericResponse<string>.BadRequestResponse(ConvertErrorsToString(errors));
        }

        private string ConvertErrorsToString(Dictionary<string, string[]> errors)
        {
            return string.Join(";", errors.Select(kvp => $"{kvp.Key}: {string.Join(",", kvp.Value)}"));
        }
    }


}
