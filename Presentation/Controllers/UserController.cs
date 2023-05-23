using Aplication.Dtos;
using Aplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public UserController(IUserServices userServices, IConfiguration configuration) {
            _userServices = userServices;
            _configuration = configuration;
        }

        private string GenerateToken(UserLoginDto user) {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<UserRegisterDto> Registration(UserRegisterDto user) {
            if (_userServices.IsUserExist(user.Email))
            {
                return new BadRequestObjectResult("User is in database");
            }
            var password = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.PasswordHash = password;
            _userServices.Add(user);

            return new OkObjectResult(user);

        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserLoginDto> Login(UserLoginDto user)
        {
            if (!_userServices.IsUserExist(user.Email)) {
                return new BadRequestObjectResult("User does not exist");
            }
            UserDto u = _userServices.GetUserByEmail(user.Email);

            if (!BCrypt.Net.BCrypt.Verify(user.PasswordHash, u.PasswordHash)) {
                return new BadRequestObjectResult("BaddPasword");
            }
            var token = GenerateToken(user);

            return new OkObjectResult(token);


        }

        [HttpGet]
        [Route("GetAllUnregister")]
        public IEnumerable<UserUnregisterDto> GetUserUnregisters()
        {
            return _userServices.GetAllUnregister();
        }

        [HttpGet, Authorize(Roles = "User")]
        [Route("GetAll")]
        public IEnumerable<UserDto> GetAll()
        {
            return _userServices.GetAll();
        }

        [HttpDelete, Authorize(Roles = "User")]
        [Route("DeleteByID")]
        public ActionResult<string> Delete(Guid id) { 
            _userServices.Delete(id);
            return new OkObjectResult("");
        }

        [HttpPatch, Authorize(Roles = "User")]
        [Route("UpdateUser")]
        public ActionResult<UserDto> Update(UserDto update)
        {
            var user= _userServices.Update(update);
            return new OkObjectResult(user);
        }

    }
}
