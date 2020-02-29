using System.ComponentModel.DataAnnotations;

namespace socialApp.API.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Pasword Lenght is wrong.")]
        public string Password { get; set; }
    }
}