using Microsoft.AspNetCore.Identity;

namespace GrooveArcade.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser() => this.Id = Guid.NewGuid().ToString();

		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiry { get; set; }
	}
}
