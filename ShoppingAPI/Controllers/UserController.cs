using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.DTO;
using ShoppingAPI.Models;
using ShoppingAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService service, IConfiguration configuration)
        {
            _userService = service;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDTO userDTO)
        {
            return _userService.Register(userDTO);
        }

        [HttpPost("Login")]
        public string Login(UserDTO userDTO) 
        {
            var user = _userService.GetUser(userDTO);

            if (user != null)
                return GenerateToken(user);
            else
                return "User Is Null";
        }

        [HttpGet("GenerateToken")]
        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , user.Username),
                new Claim(ClaimTypes.Email,user.Email)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
