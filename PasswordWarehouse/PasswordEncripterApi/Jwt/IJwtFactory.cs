using System.Collections.Immutable;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PasswordEncripterApi.Jwt
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedTokenAsync(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, IImmutableList<Claim> claims);
        string GenerateRefreshToken();
    }
}
