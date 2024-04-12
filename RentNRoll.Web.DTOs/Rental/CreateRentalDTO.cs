using RentNRoll.Services.Mapping;
using Models = RentNRoll.Data.Models;

namespace RentNRoll.Web.DTOs.Rental
{
	public class CreateRentalDTO : IMapTo<Models.Rental>
	{
		public string CustomerId { get; set; } = null!;
		public int CarId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
