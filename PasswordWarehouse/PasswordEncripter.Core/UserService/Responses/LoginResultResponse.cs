using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncripter.Core.UserService.Responses
{
    public class LoginResultResponse
    {
        public LoginResultResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        }

        public string AccessToken { get; }
        public string RefreshToken { get; }
    }
}
}
