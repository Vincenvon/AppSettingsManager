namespace AppSettingsManager.Settings
{
    public class AppSettingsManagerSetting
    {
        public string AppSettingsFileName { get; set; } = "appsettings.json";

        public string AppSettingsFilePath { get; set; } = "./";

        public string AppSettingsManagerUrl { get; set; } = "/appsettings";

        public string DbFileName { get; set; } = "AsmDb.db";

        public string DbFilePath { get; set; } = "./AsmDb";

        public string[] ExcludedSettings { get; set; }
    }
}
