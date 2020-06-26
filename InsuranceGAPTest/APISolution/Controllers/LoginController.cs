using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APISolution.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region private member variables
        private IConfiguration _config;
        #endregion

        #region Contructor - Destructor - Finalizer
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region Methods

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private Users AuthenticateUser(LoginModel login)
        {
            Users user = null;

            if (login.Username == "Admin" && login.Password == "Test2020")
            {
                user = new Users { Name = "Administrator", Email = "Administrator@domain.com", Birthdate = new DateTime(1983, 9, 23) };
            }

            return user;
        }

        private string GenerateJSONWebToken(Users user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim("Role", "AdminUser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(360),
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        #endregion
    }
}
