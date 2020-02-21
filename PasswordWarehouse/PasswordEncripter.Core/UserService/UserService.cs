using Microsoft.AspNetCore.Identity;
using PasswordEncripter.Core.UserService.Requests;
using PasswordEncripter.Core.UserService.Responses;
using PasswordEncripter.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEncripter.Core.UserService
{
    public class UserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> CreateUser(RegisterRequest rq)
        {
            var user = new User(rq.UserName)
            {
                Email = rq.UserName,
                FirstName = rq.FirstName,
                Dni = rq.Dni,
                LastName = rq.LastName,
                PassEncripter = rq.PassEncripter,
                EmailConfirmed=true
            };

            var result = await userManager.CreateAsync(user, rq.PasswordApi);

            if (!result.Succeeded)
                throw new Exception("error al crear el nuevo usuario");

            return result.Succeeded;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest rq)
        {
            var user = await userManager.FindByNameAsync(rq.UserName);

            if (user == null)
                throw new Exception("No se encontro el usuario");

            var claims = new List<Claim>();
            claims.AddRange(await userManager.GetClaimsAsync(user));
            var roles = await userManager.GetRolesAsync(user);
            
            foreach (var roleId in roles)
            {
                var role = await roleManager.FindByIdAsync(roleId);
                claims.Add(new Claim(ClaimTypes.Role, role.Id));
                claims.AddRange(await roleManager.GetClaimsAsync(role));
            }

            var isValidPassword = await userManager.CheckPasswordAsync(user, rq.Password);
            if (!isValidPassword)
            {
                await userManager.AccessFailedAsync(user);
                throw new Exception("La password ingresada no es valida");
            }

            await userManager.ResetAccessFailedCountAsync(user);

            var response = new LoginResponse(user.Id, claims.ToImmutableList());

            return response;
        }
    }
}
