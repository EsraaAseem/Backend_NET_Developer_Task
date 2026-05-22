
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectTaskManagement.Application.Abstrations.IServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Application.Features.Authentication.Register
{
    public class RegisterCommandHandler
     : IRequestHandler<RegisterCommand,
         GenericResponse<AuthResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTService _jwtService;

        public RegisterCommandHandler(
            UserManager<AppUser> userManager,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<GenericResponse<AuthResponseDto>> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _userManager.FindByEmailAsync(
                request.Model.Email);

            if (exists is not null)
            {
                return GenericResponse<AuthResponseDto>
                    .BadRequestResponse("Email already exists");
            }

            var user = new AppUser
            {
                UserName = request.Model.UserName,
                Email = request.Model.Email
            };

            var result = await _userManager.CreateAsync(
                user,
                request.Model.Password);

            if (!result.Succeeded)
            {
                return GenericResponse<AuthResponseDto>
                    .BadRequestResponse(result.Errors.First().Description);
            }
            var authModel = new AuthModel
            {
                UserName = user.UserName,
                Id = user.Id,
               // Role = "User"
            };

            var token = await _jwtService.GenerateToken(authModel);

            var response = new AuthResponseDto
            {
                Token = token,
                Email = user.Email!,
                UserName = user.UserName!
            };

            return GenericResponse<AuthResponseDto>
                .SuccessResponseWithDataAndMsg(response, "Registered successfully");
        }
    }
}
