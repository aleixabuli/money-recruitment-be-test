using System.Threading.Tasks;
using Domain.VacationalRental.Model.BookingModel;

namespace Domain.VacationalRental.Service.Contracts.BookingServices
{
    public interface IBookingService
    {
        Task<Booking> GetById(int bookingId);
    }
}
