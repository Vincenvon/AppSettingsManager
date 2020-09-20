using AppSettingsManager.DataAccess;
using AppSettingsManager.Entities;
using AppSettingsManager.Exceptions;
using AppSettingsManager.Requests;
using AppSettingsManager.Responses;

using System.Linq;

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

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var user = _userRepository.Read(u => u.UserName == loginRequest.UserName).FirstOrDefault();

            if (user == null)
                throw new WrongCredentialsException();

            if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                return new LoginResponse
                {
                    AccessToken = _jwtTokenService.Generate(user)
                };
            }
            throw new WrongCredentialsException();
        }
    }
}
