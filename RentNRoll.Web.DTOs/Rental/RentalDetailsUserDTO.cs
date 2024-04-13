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
		public string RentalDate { get; set; } = null!;
		public string ReturnDate { get; set; } = null!;
		public decimal TotalPrice { get; set; }

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<Models.Rental, RentalDetailsUserDTO>()
				.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car.Brand.Name))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Car.Category.Name))
				.ForMember(dest => dest.RentalDate, opt => opt.MapFrom(src => src.RentalDate.ToLongDateString()))
				.ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate.ToLongDateString()));
		}
	}
}
