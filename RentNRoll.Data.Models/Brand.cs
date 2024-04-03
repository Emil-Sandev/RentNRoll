using RentNRoll.Data.Common.Models;
using static RentNRoll.Common.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace RentNRoll.Data.Models
{
	public class Brand : BaseModel<int>
	{
		[Required]
		[MaxLength(BrandNameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
