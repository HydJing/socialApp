using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public AuthController(IAuthRepository repo)
        {
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
    }
}