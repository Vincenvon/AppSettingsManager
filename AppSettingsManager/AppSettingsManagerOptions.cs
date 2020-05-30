namespace AppSettingsManager
{
    public class AppSettingsManagerOptions
    {
        public string AppSettingsManagerUrl { get; set; } = "/appsettings";

        public string[] ExcludedSettings { get; set; }
    }
}
