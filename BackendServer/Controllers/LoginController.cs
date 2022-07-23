using BackendServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BackendServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private List<User> listaKorisnika = new List<User>
        {
            new User { UserName = "sergej", Password = "123456", Role = "User"},
            new User { UserName = "darija", Password = "123456", Role = "Admin"},
            new User { UserName = "marina", Password = "123456", Role = "Admin"},
            new User { UserName = "alen", Password = "98765", Role = "User"}
        };

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(User userLoginOdKlijenta)
        {
            IActionResult response = Unauthorized();

            var korisnik = ProvjeraKorisnika(userLoginOdKlijenta);

            if(korisnik != null)
            {
               var token = GenerisiToken(korisnik);
                response = Ok(new
                {
                    token
                });
            }
            
                return response;
            
        }

        public User ProvjeraKorisnika(User userLoginOdKlijenta)
        {
            var user = listaKorisnika.SingleOrDefault(korisnik => korisnik.UserName == userLoginOdKlijenta.UserName && korisnik.Password == userLoginOdKlijenta.Password);
            return user;
        }

        public string GenerisiToken(User korisnik)
        {
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var kredencijali = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);

            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, korisnik.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", korisnik.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claim,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: kredencijali
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
