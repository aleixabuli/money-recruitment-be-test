using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.VacationalRental.Model.BookingModel;

namespace Domain.VacationalRental.Service.Contracts.BookingServices
{
    public interface IBookingService
    {
        Task<Booking> GetById(int bookingId);

        void VerifyHasNights(int nights);

        Task VerifyRentalUnitsAvailability(
            int bookingNights, 
            int rentalId, DateTime 
            bookingStart,
            int unit
            );

        Task<object> CreateBooking(
            int bookingNights,
            int rentalId,
            DateTime bookingStart,
            int unit
            );

        Task<IDictionary<int, Booking>> GetAll();
    }
}
