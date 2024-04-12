using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Cars;
using RentNRoll.Services.Data.Rentals;
using RentNRoll.Services.Data.Users;
using RentNRoll.Web.DTOs.Rental;
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
		private readonly IUserService _userService;
		private readonly ICarService _carService;
		private readonly IRentalService _rentalService;

		public StripeController(IConfiguration configuration, IUserService userService, ICarService carService, IRentalService rentalService)
		{
			_configuration = configuration;
			_userService = userService;
			_carService = carService;
			_rentalService = rentalService;
		}

		[HttpPost("createCheckout")]
		public IActionResult CreateCheckoutSession([FromBody] StripePaymentDTO paymentDTO)
		{
			StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string> { "card" },
				Metadata = new Dictionary<string, string>()
				{
					{ "product", paymentDTO.Model },
					{ "rentalDate", paymentDTO.RentalDate.ToString() },
					{ "returnDate", paymentDTO.ReturnDate.ToString() },
				},
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

		[HttpPost("webhook")]
		public async Task<IActionResult> Webhook()
		{
			var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
			try
			{
				var stripeEvent = EventUtility.ConstructEvent(
				 json,
				 Request.Headers["Stripe-Signature"],
				 _configuration["Stripe:WHSecret"],
				 throwOnApiVersionMismatch: false
				);

				if (stripeEvent.Type == Events.CheckoutSessionCompleted)
				{
					var session = stripeEvent.Data.Object as Session;

					var createRentalDTO = new CreateRentalDTO
					{
						CustomerId = _userService.GetUserIdByEmail(session.CustomerDetails.Email),
						CarId = _carService.GetCarIdByModel(session.Metadata["product"]),
						TotalPrice = (decimal)(session.AmountTotal / 100.0m),
						RentalDate = DateTime.Parse(session.Metadata["rentalDate"]),
						ReturnDate = DateTime.Parse(session.Metadata["returnDate"])
					};

					await _rentalService.CreateRentalAsync(createRentalDTO);
				}
				else
				{
					Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
				}

				return Ok();
			}
			catch (StripeException e)
			{
				Console.WriteLine(e.StripeError.Message);
				return BadRequest();
			}
		}
	}
}
