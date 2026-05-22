
using System.IdentityModel.Tokens.Jwt;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Application.Abstrations.IServices
{
    public interface IJWTService
    {
        Task<string> GenerateToken(AuthModel user);
    }
}
