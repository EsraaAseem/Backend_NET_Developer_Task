

namespace ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Email { get; }
        string? UserName { get; }
    }
}
