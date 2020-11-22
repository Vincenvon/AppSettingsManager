namespace AppSettingsManager.Settings
{
    public class Settings
    {
        public ContentSettings ContentSettings { get; set; } = new ContentSettings();

        public DatabaseSettings DatabaseSettings { get; set; } = new DatabaseSettings();

        public FileSettings FileSettings { get; set; } = new FileSettings();

        public HostSettings HostSettings { get; set; } = new HostSettings();

        public JwtTokenSettings JwtTokenSettings { get; set; } = new JwtTokenSettings();

        public UserSettings UserSettings { get; set; } = new UserSettings();
    }
}
