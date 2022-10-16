using System.Threading.Tasks;

namespace Domain.VacationalRental.Repository.Contracts.Booking
{
    public interface IRentalRepository
    {
        Task<Domain.VacationalRental.Model.BookingModel.Rental> GetById(int rentalId);
    }
}
