using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PFE1.ViewModels;

namespace PFE1.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration ;
        public AuthController (UserManager<IdentityUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;


        }
        [Route("Singup")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) { await _userManager.AddToRoleAsync(user, "User"); };
            return Ok(new { user.UserName });
        }
        [Route("Signin")]
        [HttpPost]
        public async Task <ActionResult> Signin([FromBody] Personnel model)
        {
          
            var user = await _userManager.FindByNameAsync(model.Username);
           
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                #region if scope

                var claim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Site"],
                    audience: _configuration["Jwt:Site"],
                    expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );
               
                return Ok(
                    new
                    {
                       /* token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo*/
                    }
                    );

                #endregion
            }

            return Unauthorized();
        }

        }
        
        
    }
