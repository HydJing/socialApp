using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using socialApp.API.Data;
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
        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if (await _repo.userExists(username))
            {
                return BadRequest("Username already taken");
            }

            var userToCreate = new User
            {
                Username = username
            }

            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }
    }
}