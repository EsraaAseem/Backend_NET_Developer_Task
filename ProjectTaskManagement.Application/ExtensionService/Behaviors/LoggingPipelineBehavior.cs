
using MediatR;
using Microsoft.Extensions.Logging;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.ExtensionService.Behaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : GenericResponse<string>

    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
            "Starting request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

            var result = await next();

            if (result.IsSuccess == false)
            {
                _logger.LogError(
                    "Request failure {@RequestName}, {@Error}, {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    result.Message,
                    DateTime.UtcNow);
            }

            _logger.LogInformation(
                "Completed request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            return result;
        }
    }
}
