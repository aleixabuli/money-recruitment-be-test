using System;
using System.Collections.Generic;

namespace Application.VacationRental.Calendar.DTO.Response
{
    public class CalendarDateViewModelResponse
    {
        public DateTime Date { get; set; }
        public List<CalendarBookingViewModelResponse> Bookings { get; set; }
        public List<PreparationTimesResponse> PreparationTimes { get; set; }
    }
}
