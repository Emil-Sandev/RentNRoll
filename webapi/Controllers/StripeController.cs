using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RentNRoll.Web.DTOs.Stripe;
using Stripe;
using Stripe.Checkout;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class StripeController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public StripeController(IConfiguration configuration) => _configuration = configuration;

		[HttpPost("createCheckout")]
		public IActionResult CreateCheckoutSession([FromBody] StripePaymentDTO paymentDTO)
		{
			StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string> { "card" },
				LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmountDecimal = paymentDTO.TotalPrice * 100,
							Currency = "usd",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = paymentDTO.Model,
								Images = new List<string?> { paymentDTO.ImageUrl },
							},
						},
						Quantity = 1,
					},
				},
				Mode = "payment",
				SuccessUrl = "https://localhost:4200/success",
				CancelUrl = "https://localhost:4200/cancel",
			};

			var sessionService = new SessionService();
			var session = sessionService.Create(options);

			return Ok(new { url = session.Url });
		}
	}
}
