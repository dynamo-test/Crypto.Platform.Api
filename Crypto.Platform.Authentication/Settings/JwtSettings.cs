namespace Crypto.Platform.Authentication.Settings
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;

        public int Expires { get; set; }

        public string Username { get; set; } = null!;
    }
}
