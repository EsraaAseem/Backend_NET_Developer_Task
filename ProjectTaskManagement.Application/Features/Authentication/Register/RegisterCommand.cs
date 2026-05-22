
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;


namespace ProjectTaskManagement.Application.Features.Authentication.Register
{

    public record RegisterCommand(
        RegisterDto Model)
        : IRequest<GenericResponse<AuthResponseDto>>;
}
