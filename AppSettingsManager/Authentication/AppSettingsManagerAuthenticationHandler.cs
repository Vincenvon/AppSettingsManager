using AppSettingsManager.Services;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AppSettingsManager.Authentication
{
    public class AppSettingsManagerAuthenticationHandler : AuthenticationHandler<AppSettingsManagerAuthenticationSchemeOptions>
    {
        private const string AuthorizationHeaderName = "Authorization";
        private const string SchemeName = "Bearer";

        private readonly IUserManager _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AppSettingsManagerAuthenticationHandler(
            IOptionsMonitor<AppSettingsManagerAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IJwtTokenService jwtTokenService,
            IUserManager userManager) : base(options, logger, encoder, clock)
        {
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(AuthorizationHeaderName))
            {
                //Authorization header not in request
                return AuthenticateResult.NoResult();
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers[AuthorizationHeaderName], out AuthenticationHeaderValue headerValue))
            {
                //Invalid Authorization header
                return AuthenticateResult.NoResult();
            }

            if (!SchemeName.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                //Not Basic authentication header
                return AuthenticateResult.NoResult();
            }

            try
            {
                var token = headerValue.Parameter;
                var user = _jwtTokenService.ParseToken(token);
                var ticket = new AuthenticationTicket(_userManager.GetClaimsPrincipal(user), Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail("Invalid username or password");
            }
        }
    }
}
