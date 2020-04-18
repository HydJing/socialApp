using Microsoft.AspNetCore.Identity;
using socialApp.API.Models;

namespace socialApp.API.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}