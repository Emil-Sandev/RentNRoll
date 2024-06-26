﻿namespace RentNRoll.Web.DTOs.Stripe
{
	public class StripePaymentDTO
	{
		public string Model { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal TotalPrice { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
