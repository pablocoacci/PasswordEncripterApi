using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PasswordEncripter.Core.UserService;
using PasswordEncripter.Core.UserService.Requests;
using PasswordEncripter.Core.UserService.Responses;
using PasswordEncripterApi.Jwt;

namespace PasswordEncripterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserService userService;
        private readonly IJwtFactory jwtFactory;
        private readonly IOptions<JwtIssuerOptions> jwtOptions;

        public AccountController(UserService userService, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            this.userService = userService;
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var result = await userService.CreateUser(request);

            return Ok("Login ok");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResultResponse>> Login(LoginRequest request)
        {
            var result = await userService.LoginUser(request);

            var identity = jwtFactory.GenerateClaimsIdentity(request.UserName, result.Id, result.Claims);
            var token = await jwtFactory.GenerateEncodedTokenAsync(request.UserName, identity);
            var refreshToken = jwtFactory.GenerateRefreshToken();

            return Ok(new LoginResultResponse(token, refreshToken));
        }
    }
}