namespace AppSettingsManager.Settings
{
    public class JwtTokenSettings
    {
        public string Secret { get; set; } = "asdv234234^&%&^%&^hjsdfb2%%%";

        public string Issuer { get; set; } = "https://github.com/Vincenvon/AppSettingsManager";

        public string Audience { get; set; } = "https://github.com/Vincenvon/AppSettingsManager";

        public int ExpiresAfterMinutes { get; set; } = 30;
    }
}
