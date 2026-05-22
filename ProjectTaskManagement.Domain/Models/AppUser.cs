
using Microsoft.AspNetCore.Identity;

namespace ProjectTaskManagement.Domain.Models
{
    public class AppUser:IdentityUser
    {
        public ICollection<Project> Projects { get; set; }
    }
}
