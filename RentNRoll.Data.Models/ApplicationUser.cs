using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentNRoll.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() => this.Id = Guid.NewGuid().ToString();

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string EGN { get; set; } = null!;

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
