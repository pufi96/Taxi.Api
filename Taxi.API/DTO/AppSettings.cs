namespace Taxi.API.DTO
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public JwtSettings Jwt { get; set; }
        public string BugSnagKey { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
}
