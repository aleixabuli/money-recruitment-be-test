using System.Threading.Tasks;
using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IGetBooking _getBooking;
        private readonly ICreateBooking _createBooking;

        public BookingsController(
            IGetBooking getBooking,
            ICreateBooking createBooking
            )
        {
            _getBooking = getBooking;
            _createBooking = createBooking;
        }

        [HttpGet]
        [Route("{bookingId:int}")]
        public async Task<ActionResult> Get(int bookingId)
        {
            
            var response = await _getBooking.Execute(bookingId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(BookingBindingModelRequest booking)
        {
            var response = await _createBooking.Execute(booking);
            return Ok(response);
        }
    }
}
