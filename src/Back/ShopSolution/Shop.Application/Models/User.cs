namespace Shop.Application.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
