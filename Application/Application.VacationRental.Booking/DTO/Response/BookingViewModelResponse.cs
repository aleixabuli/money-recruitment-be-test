using System;

namespace Application.VacationRental.Booking.DTO.Response
{
    public class BookingViewModelResponse
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public DateTime Start { get; set; }
        public int Nights { get; set; }
    }
}
