namespace RentNRoll.Web.DTOs.Car
{
	public class CarQueryModel
	{
		public string? Brand { get; set; }
		public string? Category { get; set; }
		public int MinPrice { get; set; } = 0;
		public int MaxPrice { get; set; } = 300;
		public int CurrentPage { get; set; } = 1;
		public int CarsPerPage { get; set; } = 3;
	}
}
