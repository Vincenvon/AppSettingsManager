namespace AppSettingsManager.Entities
{
    public class User: Entity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string LastAccessToken { get; set; }

        public string LastRefreshToken { get; set; }
    }
}
