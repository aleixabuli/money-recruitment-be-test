using System.Collections.Generic;

namespace Application.VacationRental.Calendar.DTO.Response
{
    public class CalendarViewModelResponse
    {
        public int RentalId { get; set; }
        public List<CalendarDateViewModelResponse> Dates { get; set; }
    }
}
