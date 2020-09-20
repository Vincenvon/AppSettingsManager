using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

namespace AppSettingsManager.Services
{
    public interface IUserManager
    {
        LoginResponse Login(LoginRequest loginRequest);
    }
}
