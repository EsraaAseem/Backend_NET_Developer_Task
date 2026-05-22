
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Authentication.Login
{
    public record LoginCommand(
     LoginDto Model)
     : IRequest<GenericResponse<AuthResponseDto>>;
}
