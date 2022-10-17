using Application.VacationRental.Booking.DTO.Response;
using Domain.VacationalRental.Model.BookingModel;
using Domain.VacationalRental.Repository.Contracts.Booking;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTime bookingStart,
            int unit
            )
        {
            //THIS double foreach structure (and this "GetAll" call) are VERY inefficient.
            //In an environment that we have a database, the "count"
            //value will be extracted directly using a single query from the database

            var rental = await _rentalService.GetById(rentalId);

            if (rental.OccupiedUnitsNumber.ContainsKey(unit) 
                && rental.OccupiedUnitsNumber[unit] == true)
            {
                throw new ApplicationException("Unit not available");
            }

            var allBookings = await _bookingRepository.GetAll();

            for (var i = 0; i < bookingNights; i++)
            {
                var count = 0;

                foreach (var bookingForEach in allBookings.Values)
                {
                    count += IsBookingAvailableForRental(
                        bookingForEach, 
                        bookingNights,
                        rental, 
                        bookingStart
                        );
                }

                if (count >= rental.Units)
                {
                    throw new ApplicationException("Not available");
                }
                    
            }
        }

        public async Task<object> CreateBooking(
            int bookingNights, 
            int rentalId, 
            DateTime bookingStart,
            int unit
            )
        {
            var allBookings = await _bookingRepository.GetAll();

            var key = new BookingResourceIdViewModelResponse { Id = allBookings.Keys.Count + 1 };

            await _bookingRepository.Create(
                key.Id, 
                bookingNights, 
                rentalId, 
                bookingStart,
                unit
                );

            await _rentalService.OccupyUnit(
                rentalId, 
                unit
                );

            return key;
        }

        public async Task<IDictionary<int, Booking>> GetAll() 
        {
            var allBookings = await _bookingRepository.GetAll();
            return allBookings;
        }

        /// <summary>
        /// Returns 1 if it is available, returns 0 if not
        /// </summary>
        /// <param name="bookingForEach"></param>
        /// <param name="bookingNights"></param>
        /// <param name="rental"></param>
        /// <param name="bookingStart"></param>
        /// <returns></returns>
        private int IsBookingAvailableForRental(
            Booking bookingForEach, 
            int bookingNights, 
            Rental rental, 
            DateTime bookingStart
            )
        {
            int returnValue = 0;

            if (bookingForEach.RentalId == rental.Id
                    && (bookingForEach.Start <= bookingStart.Date && bookingForEach.Start.AddDays(bookingForEach.Nights) > bookingStart.Date)
                    || (bookingForEach.Start < bookingStart.AddDays(bookingNights) && bookingForEach.Start.AddDays(bookingForEach.Nights) >= bookingStart.AddDays(bookingNights))
                    || (bookingForEach.Start > bookingStart && bookingForEach.Start.AddDays(bookingForEach.Nights) < bookingStart.AddDays(bookingNights)))
            {
                returnValue = 1;
            }

            return returnValue;
        }

    }
}
