using AutoMapper;
using RentNRoll.Data.Models;
using RentNRoll.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RentNRoll.Web.DTOs.Register
{
	public class RegisterDTO : IMapTo<ApplicationUser>, IHaveCustomMappings
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Username { get; set; }
		public required string Password { get; set; }

		[EmailAddress]
		public required string Email { get; set; }
		public required string Phone { get; set; }
		public required string EGN { get; set; }

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<RegisterDTO, ApplicationUser>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
				.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
				.ForMember(dest => dest.SecurityStamp, opt => Guid.NewGuid().ToString());
		}
	}
}