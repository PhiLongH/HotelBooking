using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string UserID { get; set; }
        public string Name { get; set; }
        
    }
}
