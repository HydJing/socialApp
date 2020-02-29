using System.ComponentModel.DataAnnotations;

namespace socialApp.API.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}