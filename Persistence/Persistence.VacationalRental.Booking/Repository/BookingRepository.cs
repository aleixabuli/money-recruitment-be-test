using Domain.VacationalRental.Repository.Contracts.Booking;
using Persistence.VacationalRental.Booking.Model;
using Persistence.VacationalRental.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.VacationalRental.Booking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        
        //private readonly IDictionary<int, BookingViewModelResponse> _bookings;
        private readonly IDictionary<int, BookingDB> _bookings;
        IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Booking, BookingDB> _bookingMapper;
        public BookingRepository(
            IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Booking, BookingDB> bookingMapper,
            IDictionary<int, BookingDB> bookings
            )
        {
            _bookingMapper = bookingMapper;
            _bookings = bookings;
        }

        public async Task<IDictionary<int, Domain.VacationalRental.Model.BookingModel.Booking>> GetAll()
        {
            IDictionary<int, Domain.VacationalRental.Model.BookingModel.Booking> result = new Dictionary<int, Domain.VacationalRental.Model.BookingModel.Booking>();
            foreach (var booking in _bookings)
            {
                result.Add(booking.Key, _bookingMapper.MapToDomainModel(booking.Value));
            }

            return result;
        }

        public async Task<Domain.VacationalRental.Model.BookingModel.Booking> GetById(int bookingId)
        {
            if (!_bookings.ContainsKey(bookingId))
            {
                return null;
            }
            var bookingTarget = _bookingMapper.MapToDomainModel(_bookings[bookingId]);
            return bookingTarget;
        }

        public async Task Create(
            int keyId,
            int bookingNights,
            int rentalId,
            DateTime bookingStart,
            int unit
            )
        {
            _bookings.Add(keyId, new BookingDB
            {
                Id = keyId,
                Nights = bookingNights,
                RentalId = rentalId,
                Start = bookingStart,
                Unit = unit
            });
        }
    }
}
