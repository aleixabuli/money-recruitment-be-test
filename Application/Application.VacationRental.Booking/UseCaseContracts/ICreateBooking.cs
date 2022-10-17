using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.DTO.Response;
using System.Threading.Tasks;

namespace Application.VacationRental.Booking.UseCaseContracts
{
    public interface ICreateBooking
    {
        Task<BookingResourceIdViewModelResponse> Execute(BookingBindingModelRequest booking);
    }
}
