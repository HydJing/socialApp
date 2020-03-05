using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using socialApp.API.Data;
using socialApp.API.Dtos;
using socialApp.API.Models;

namespace socialApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            userRegisterDto.Username = userRegisterDto.Username.ToLower();

            if (await _repo.userExists(userRegisterDto.Username))
            {
                return BadRequest("Username already taken");
            }

            var userToCreate = new User
            {
                Username = userRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {

            throw new Exception("exception here~");

            // check the DB do we have a customer that matchs the username and password
            var UserFromRepo = await _repo.Login(userLoginDto.Username, userLoginDto.Password);

            // return login failed with no general information
            if (UserFromRepo == null) {
                return Unauthorized();
            }

            // claims -> calimIdentity -> claimprincipal
            // set up the claims data
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, UserFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, UserFromRepo.Username),
            };

            // get token key from the pre-defined string in the app settings, it should be at least more than 12 random characters
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // generates the credentials by long length secret token key with algorithem
            var creds = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha512Signature);

            // set up the token details for create later
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            // initialize the token handler to create and write
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new 
            {
                token = tokenHandler.WriteToken(token)
            });
        }


    }
}