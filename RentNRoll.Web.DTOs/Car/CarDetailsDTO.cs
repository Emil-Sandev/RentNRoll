using AutoMapper;
using RentNRoll.Services.Mapping;
using Models = RentNRoll.Data.Models;

namespace RentNRoll.Web.DTOs.Car
{
    public class CarDetailsDTO : IMapFrom<Models.Car>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Seats { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Models.Car, CarDetailsDTO>()
                .ForMember(des => des.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(des => des.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
