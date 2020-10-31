using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;

using System.Linq;
using System.Threading.Tasks;

namespace AppSettingsManager.Setup
{
    internal static class UserSetuper
    {
        internal static Task SetupAsync(Settings.Settings settings)
        {
            var repository = new Repository<User>(settings.DatabaseSettings.FolderPath,
                settings.DatabaseSettings.FileName);

            var user = repository.Read(u => u.UserName == settings.UserSettings.UserName).FirstOrDefault();

            if (user == null)
            {
                repository.Create(new User
                {
                    UserName = settings.UserSettings.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(settings.UserSettings.Password)
                });
            }

            return Task.CompletedTask;
        }
    }
}
