﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentNRoll.Data.Models
{
	public class Rental
	{
		[ForeignKey(nameof(Car))]
		public int CarId { get; set; }

		[Required]
		public virtual Car Car { get; set; } = null!;

		[ForeignKey(nameof(Customer))]
		public string CustomerId { get; set; } = null!;

		[Required]
		public virtual ApplicationUser Customer { get; set; } = null!;

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
