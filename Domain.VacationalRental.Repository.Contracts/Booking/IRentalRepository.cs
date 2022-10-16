using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.VacationalRental.Repository.Contracts.Booking
{
    public interface IRentalRepository
    {
        Task<Domain.VacationalRental.Model.BookingModel.Rental> GetById(int rentalId);
        Task<IDictionary<int, Domain.VacationalRental.Model.BookingModel.Rental>> GetAll();
        void Create(
                int keyId,
                int units
                );
    }
}
