using Application.VacationRental.Booking.DTO.Response;
using System.Threading.Tasks;

namespace Application.VacationRental.Booking.UseCaseContracts
{
    public interface IGetBooking
    {
        Task<BookingViewModelResponse> Execute(int bookingId);
    }
}
