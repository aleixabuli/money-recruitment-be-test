using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Http;
using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.DTO.Response;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        //private readonly IDictionary<int, RentalViewModel> _rentals;
        //private readonly IDictionary<int, BookingViewModelResponse> _bookings;
        private IGetBooking _getBooking;
        private readonly ICreateBooking _createBooking;

        public BookingsController(
            //IDictionary<int, RentalViewModel> rentals,
            //IDictionary<int, BookingViewModelResponse> bookings,
            IGetBooking getBooking,
            ICreateBooking createBooking
            )
        {
            //_rentals = rentals;
            //_bookings = bookings;
            _getBooking = getBooking;
            _createBooking = createBooking;
        }

        [HttpGet]
        [Route("{bookingId:int}")]
        public async Task<ActionResult> Get(int bookingId)//<BookingViewModelResponse>> Get(int bookingId)
        {
            
            var response = await _getBooking.Execute(bookingId);

            return Ok(response);
            /*
            if (!_bookings.ContainsKey(bookingId))
                throw new ApplicationException("Booking not found");

            return _bookings[bookingId];*/
        }

        [HttpPost]
        public async Task<ActionResult> Post(BookingBindingModelRequest booking) //ResourceIdViewModel Post(BookingBindingModelRequest model)
        {
            var response = await _createBooking.Execute(booking);
            /*
            if (model.Nights <= 0)
                throw new ApplicationException("Nigts must be positive");
            if (!_rentals.ContainsKey(model.RentalId))
                throw new ApplicationException("Rental not found");

            for (var i = 0; i < model.Nights; i++)
            {
                var count = 0;
                foreach (var booking in _bookings.Values)
                {
                    if (booking.RentalId == model.RentalId
                        && (booking.Start <= model.Start.Date && booking.Start.AddDays(booking.Nights) > model.Start.Date)
                        || (booking.Start < model.Start.AddDays(model.Nights) && booking.Start.AddDays(booking.Nights) >= model.Start.AddDays(model.Nights))
                        || (booking.Start > model.Start && booking.Start.AddDays(booking.Nights) < model.Start.AddDays(model.Nights)))
                    {
                        count++;
                    }
                }
                if (count >= _rentals[model.RentalId].Units)
                    throw new ApplicationException("Not available");
            }


            var key = new ResourceIdViewModel { Id = _bookings.Keys.Count + 1 };

            _bookings.Add(key.Id, new BookingViewModelResponse
            {
                Id = key.Id,
                Nights = model.Nights,
                RentalId = model.RentalId,
                Start = model.Start.Date
            });

            return key;
            */

            return Ok(response);
        }
    }
}
