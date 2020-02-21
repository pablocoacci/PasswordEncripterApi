using System;
using System.Collections.Immutable;
using System.Security.Claims;

namespace PasswordEncripter.Core.UserService.Responses
{
    public class LoginResponse
    {
        public LoginResponse(string id, IImmutableList<Claim> claims)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Claims = claims ?? throw new ArgumentNullException(nameof(claims));
        }

        public string Id { get; set; }
        public IImmutableList<Claim> Claims { get; internal set; }
    }
}
