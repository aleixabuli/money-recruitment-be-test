using Application.VacationRental.Calendar.DTO.Response;
using Application.VacationRental.Calendar.UseCaseContracts;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.VacationRental.Calendar.UseCase
{
    public class GetCalendar : IGetCalendar
    {
        private readonly IBookingService _bookingService;
        private readonly IRentalService _rentalService;

        public GetCalendar(
            IBookingService bookingService,
            IRentalService rentalService
            )
        {
            _bookingService = bookingService;
            _rentalService = rentalService;
        }
        public async Task<CalendarViewModelResponse> Execute(
            int rentalId, 
            DateTime start, 
            int nights
            )
        {
            _bookingService.VerifyHasNights(nights);

            await _rentalService.VerifyById(rentalId);

            var allBookings = await _bookingService.GetAll();

            var result = new CalendarViewModelResponse
            {
                RentalId = rentalId,
                Dates = new List<CalendarDateViewModelResponse>()
            };

            //THIS double foreach structure is VERY inefficient.
            //In an environment that we have a database, the resultant
            //value will be extracted directly using a single query from the database
            for (var i = 0; i < nights; i++)
            {
                var date = new CalendarDateViewModelResponse
                {
                    Date = start.Date.AddDays(i),
                    Bookings = new List<CalendarBookingViewModelResponse>()
                };

                foreach (var booking in allBookings.Values)
                {
                    if (booking.RentalId == rentalId
                        && booking.Start <= date.Date && booking.Start.AddDays(booking.Nights) > date.Date)
                    {
                        date.Bookings.Add(new CalendarBookingViewModelResponse { Id = booking.Id });
                    }
                }

                result.Dates.Add(date);
            }

            return result;
        }
    }
}
