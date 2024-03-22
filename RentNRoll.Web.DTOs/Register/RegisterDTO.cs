using System.ComponentModel.DataAnnotations;

namespace RentNRoll.Web.DTOs.Register
{
	public class RegisterDTO
	{
		public required string Username { get; set; }
		public required string Password { get; set; }

		[EmailAddress]
		public required string Email { get; set; }
	}
}
