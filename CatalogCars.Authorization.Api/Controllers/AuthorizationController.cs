using CatalogCars.Authorization.Common;
using CatalogCars.Authorization.Models;
using CatalogCars.Model.Database;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CatalogCars.Authorization.Api.Controllers
{
    [ApiController]
    [Route("api/authorization")]
    public class AuthorizationController : Controller
    {
        private readonly AuthorizationDataManager _dataManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthorizationController(AuthorizationDataManager dataManager, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private string GenerateJWT(ApplicationUser user, string role)
        {
            var securityKey = AuthorizationOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("role", role),
                new Claim(JwtRegisteredClaimNames.Sub, $"{user.Id}"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            };

            var token = new JwtSecurityToken(AuthorizationOptions.Issuer, AuthorizationOptions.Audience,
                claims, expires: DateTime.Now.AddSeconds(AuthorizationOptions.TokenLifetime), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> AuthenticateUserAsync(string emailOrLogin, string password)
        {
            var userEmail = await _userManager.FindByEmailAsync(emailOrLogin);
            var userName = await _userManager.FindByNameAsync(password);

            if (userEmail != null || userName != null)
            {
                var user = userEmail != null ? userEmail : userName;

                if ((await _signInManager.PasswordSignInAsync(user, password, false, false)).Succeeded)
                {
                    return user;
                }
            }

            return null;
        }

        [HttpPost]
        [Route("~/api/authorization/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await AuthenticateUserAsync(viewModel.EmailOrLogin, viewModel.Password);

                if (user != null)
                {
                    return Ok(new
                    {
                        AccessToken = GenerateJWT(user,
                        (await _userManager.GetRolesAsync(user)).First())
                    });
                }
            }

            return Unauthorized();
        }
    }
}
