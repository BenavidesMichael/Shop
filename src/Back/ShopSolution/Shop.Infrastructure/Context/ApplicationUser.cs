using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
