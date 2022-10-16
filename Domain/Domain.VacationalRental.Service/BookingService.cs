using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.DTO.Response;
using Domain.VacationalRental.Model.BookingModel;
using Domain.VacationalRental.Repository.Contracts.Booking;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VacationalRental.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRentalService _rentalService;

        public BookingService(
            IBookingRepository bookingRepository,
            IRentalService rentalService
            )
        {
            _bookingRepository = bookingRepository;
            _rentalService = rentalService;
        }

        public async Task<Booking> GetById(int bookingId)
        {
            var booking = await _bookingRepository.GetById(bookingId);

            return booking;
        }

        public void VerifyHasNights(int nights)
        {
            if (nights <= 0)
            {
                throw new ApplicationException("Nigts must be positive");
            }
        }

        public async Task VerifyRentalUnitsAvailability(
            int bookingNights, 
            int rentalId, 
            DateTime bookingStart
            )
        {
            //THIS double foreach structure is VERY ineficient.
            //In an environment that we have a database, the "count"
            //value will be extracted directly using a single query in the database

            for (var i = 0; i < bookingNights; i++)
            {
                var count = 0;

                var allBookings = await _bookingRepository.GetAll();

                foreach (var bookingForEach in allBookings.Values)
                {
                    count += IsBookingAvailableForRental(bookingForEach, bookingNights, rentalId, bookingStart);
                }

                var rental = await _rentalService.GetById(rentalId);

                if (count >= rental.Units)
                {
                    throw new ApplicationException("Not available");
                }
                    
            }
        }

        public async Task<object> CreateBooking(
            int bookingNights, 
            int rentalId, 
            DateTime bookingStart
            )
        {
            var allBookings = await _bookingRepository.GetAll();

            var key = new BookingResourceIdViewModelResponse { Id = allBookings.Keys.Count + 1 };

            await _bookingRepository.Create(
                key.Id, 
                bookingNights, 
                rentalId, 
                bookingStart
                );

            return key;
        }

        private int IsBookingAvailableForRental(Booking bookingForEach, int bookingNights, int rentalId, DateTime bookingStart)
        {
            int returValue = 0;

            if (bookingForEach.RentalId == rentalId
                        && (bookingForEach.Start <= bookingStart.Date && bookingForEach.Start.AddDays(bookingForEach.Nights) > bookingStart.Date)
                        || (bookingForEach.Start < bookingStart.AddDays(bookingNights) && bookingForEach.Start.AddDays(bookingForEach.Nights) >= bookingStart.AddDays(bookingNights))
                        || (bookingForEach.Start > bookingStart && bookingForEach.Start.AddDays(bookingForEach.Nights) < bookingStart.AddDays(bookingNights)))
            {
                returValue++;
            }

            return returValue;
        }
    }
}
