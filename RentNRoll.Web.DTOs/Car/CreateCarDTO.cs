using Microsoft.AspNetCore.Http;

namespace RentNRoll.Web.DTOs.Car
{
	public class CreateCarDTO
	{
		public string Model { get; set; } = null!;
		public int Year { get; set; }
		public decimal PricePerDay { get; set; }
		public string Brand { get; set; } = null!;
		public string Category { get; set; } = null!;
		public string? Description { get; set; }
		public IFormFile? Image { get; set; }
		public string LicensePlate { get; set; } = null!;
        public int Seats { get; set; }
	}
}
