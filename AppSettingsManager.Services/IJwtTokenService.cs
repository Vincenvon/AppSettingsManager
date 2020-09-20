using AppSettingsManager.Entities;

namespace AppSettingsManager.Services
{
    public interface IJwtTokenService
    {
        string Generate(User user);
    }
}
