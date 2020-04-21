using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace socialApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("userWithRoles")]
        public IActionResult GetUsersWithRoles()
        {
            return Ok("Only Admins can see this");
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photoForModeration")]
        public IActionResult GetPhotosForModeration()
        {
            return Ok("Admins or moderators can see this");
        }
    }
}