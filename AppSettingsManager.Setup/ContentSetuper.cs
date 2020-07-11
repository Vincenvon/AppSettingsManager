using AppSettingsManager.Settings;
using AppSettingsManager.UI;

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsManager.Setup
{
    internal static class ContentSetuper
    {
        internal static async Task SetupAsync(ContentSettings contentSettings)
        {
            await SetupJsAsync(contentSettings);
            await SetupImagesAsync(contentSettings);
            await SetupHtmlAsync(contentSettings);
        }

        private static async Task SetupJsAsync(ContentSettings contentSettings)
        {
            using (var fileStream = typeof(UiConstans).Assembly
                .GetManifestResourceStream("AppSettingsManager.UI.Content.js.application.js"))
            using (var reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var fileContent = await reader.ReadToEndAsync();
                fileContent = fileContent.Replace(UiConstans.ImagesFolderPath, contentSettings.ImagesRequestPath);

                CreateFolderIsNotExists(contentSettings.JsFolderPath);
                File.WriteAllText(Path.Combine(contentSettings.JsFolderPath, "application.js"), fileContent);
            }
        }

        private static async Task SetupImagesAsync(ContentSettings contentSettings)
        {
            using (var fileStream = typeof(UiConstans).Assembly
                .GetManifestResourceStream("AppSettingsManager.UI.Content.images.15f2789dd231f36d43a4839306b3a2cb.svg"))
            using (var reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var fileContent = await reader.ReadToEndAsync();

                CreateFolderIsNotExists(contentSettings.ImagesFolderPath);
                File.WriteAllText(Path.Combine(contentSettings.ImagesFolderPath, "15f2789dd231f36d43a4839306b3a2cb.svg"), fileContent);
            }
        }

        private static async Task SetupHtmlAsync(ContentSettings contentSettings)
        {
            using (var fileStream = typeof(UiConstans).Assembly.GetManifestResourceStream("AppSettingsManager.UI.Content.index.html"))
            using (var reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var fileContent = await reader.ReadToEndAsync();
                fileContent = fileContent.Replace(UiConstans.JsFolderPath, contentSettings.JsRequestPath);

                CreateFolderIsNotExists(contentSettings.HtmlFolderPath);
                File.WriteAllText(Path.Combine(contentSettings.HtmlFolderPath, "index.html"), fileContent);
            }
        }

        private static void CreateFolderIsNotExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
