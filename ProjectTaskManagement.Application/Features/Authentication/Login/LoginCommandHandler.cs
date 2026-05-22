
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectTaskManagement.Application.Abstrations.IServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Application.Features.Authentication.Login
{
    public class LoginCommandHandler
      : IRequestHandler<LoginCommand,
          GenericResponse<AuthResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTService _jwtService;

        public LoginCommandHandler(
            UserManager<AppUser> userManager,
            IJWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<GenericResponse<AuthResponseDto>> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(
                request.Model.Email);

            if (user is null)
            {
                return GenericResponse<AuthResponseDto>
                    .BadRequestResponse("Invalid credentials");
            }

            var validPassword =
                await _userManager.CheckPasswordAsync(
                    user,
                    request.Model.Password);

            if (!validPassword)
            {
                return GenericResponse<AuthResponseDto>
                    .BadRequestResponse("Invalid credentials");
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
                .SuccessResponseWithDataAndMsg(response, "Login successful");
        }
    }
}