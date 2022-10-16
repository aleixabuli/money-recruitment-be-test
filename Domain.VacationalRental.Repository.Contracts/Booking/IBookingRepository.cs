using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VacationalRental.Repository.Contracts.Booking
{
    public interface IBookingRepository
    {
        Task<Domain.VacationalRental.Model.BookingModel.Booking> GetById(int bookingId);
        Task<IDictionary<int, Domain.VacationalRental.Model.BookingModel.Booking>> GetAll();
        Task Create(
            int keyId,
            int bookingNights,
            int rentalId,
            DateTime bookingStart);
    }
}
