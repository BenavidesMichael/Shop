namespace Shop.Application.Models.AppSettings
{
    public class JWTSetting
    {
        public string? Key { get; init; }
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
    }
}
