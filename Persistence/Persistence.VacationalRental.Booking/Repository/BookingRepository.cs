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

        public async Task<Domain.VacationalRental.Model.BookingModel.Booking> GetById(int bookingId)
        {
            if (!_bookings.ContainsKey(bookingId))
            {
                return null;
            }
            var bookingTarget = _bookingMapper.MapToDomainModel(_bookings[bookingId]);
            return bookingTarget;
        }
    }
}
