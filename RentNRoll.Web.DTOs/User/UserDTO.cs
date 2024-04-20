using AutoMapper;
using RentNRoll.Data.Models;
using RentNRoll.Services.Mapping;

namespace RentNRoll.Web.DTOs.User
{
	public class UserDTO : IMapFrom<ApplicationUser>, IHaveCustomMappings
	{
		public string Id { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Phone { get; set; } = null!;
		public string EGN { get; set; } = null!;

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<ApplicationUser, UserDTO>()
				.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
		}
	}
}
