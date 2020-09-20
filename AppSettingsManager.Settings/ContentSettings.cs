namespace AppSettingsManager.Settings
{
    public class ContentSettings
    {
        public string HtmlFolderPath { get; set; } = "wwwroot";

        public string HtmlRequestPath { get; set; } = "";

        public string ImagesFolderPath { get; set; } = @"wwwroot\images";

        public string ImagesRequestPath { get; set; } = "images";

        public string JsFolderPath { get; set; } = @"wwwroot\js";

        public string JsRequestPath { get; set; } = "js";
    }
}
