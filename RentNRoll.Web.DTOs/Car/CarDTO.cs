using RentNRoll.Services.Mapping;
using Models = RentNRoll.Data.Models;

namespace RentNRoll.Web.DTOs.Car
{
	public class CarDTO : IMapFrom<Models.Car>
	{
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
	}
}
