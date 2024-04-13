using AutoMapper;
using RentNRoll.Services.Mapping;
using Models = RentNRoll.Data.Models;

namespace RentNRoll.Web.DTOs.Rental
{
	public class RentalDetailsUserDTO : IMapFrom<Models.Rental>, IHaveCustomMappings
	{
		public string Model { get; set; } = null!;
		public string Brand { get; set; } = null!;
		public string Category { get; set; } = null!;
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public decimal TotalPrice { get; set; }

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<Models.Rental, RentalDetailsUserDTO>()
				.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car.Brand.Name))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Car.Category.Name));
		}
	}
}
