using AppSettingsManager.Entities;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using System.Security.Claims;

namespace AppSettingsManager.Services
{
    public interface IUserManager
    {
        LoginResponse Login(LoginRequest loginRequest);

        ClaimsPrincipal GetClaimsPrincipal(User user);
    }
}
