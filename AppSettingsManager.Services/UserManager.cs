using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Exceptions;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using System.Linq;
using System.Security.Claims;

namespace AppSettingsManager.Services
{
    public class UserManager : IUserManager
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRepository<User> _userRepository;

        public UserManager(IRepository<User> userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            var dbUser = _userRepository.Read(u => u.UserName == user.UserName
            && u.Id == user.Id
            && u.LastAccessToken == user.LastAccessToken).FirstOrDefault();

            if (user == null)
                throw new WrongCredentialsException();

            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                }, "Bearer"));
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var user = _userRepository.Read(u => u.UserName == loginRequest.UserName).FirstOrDefault();

            if (user == null)
                throw new WrongCredentialsException();

            if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                var token = _jwtTokenService.Generate(user);
                user.LastAccessToken = token;

                _userRepository.Update(user);

                return new LoginResponse
                {
                    AccessToken = token
                };
            }
            throw new WrongCredentialsException();
        }
    }
}
