using System.Threading.Tasks;

namespace Domain.VacationalRental.Repository.Contracts.Booking
{
    public interface IBookingRepository
    {
        Task<Domain.VacationalRental.Model.BookingModel.Booking> GetById(int bookingId);
    }
}
