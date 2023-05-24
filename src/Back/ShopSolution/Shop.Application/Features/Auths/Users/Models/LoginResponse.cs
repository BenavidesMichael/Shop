namespace Shop.Application.Features.Auths.Users.Models
{
    public class LoginResponse
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Phone { get; set; }
        public string? Token { get; set; }

        public SendAddress? SendAddress { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
}
