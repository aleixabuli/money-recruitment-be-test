using Application.VacationRental.Calendar.DTO.Response;
using System;
using System.Threading.Tasks;

namespace Application.VacationRental.Calendar.UseCaseContracts
{
    public interface IGetCalendar
    {
        Task<CalendarViewModelResponse> Execute(
            int rentalId,
            DateTime start,
            int nights
            );
    }
}
