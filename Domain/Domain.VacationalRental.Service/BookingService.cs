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

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> GetById(int bookingId)
        {
            var booking = await _bookingRepository.GetById(bookingId);
            //var bookingResponse = _mapper.Map(booking);
            return booking;
        }
    }
}
