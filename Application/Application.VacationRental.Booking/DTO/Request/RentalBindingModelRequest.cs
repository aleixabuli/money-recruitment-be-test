using System.ComponentModel.DataAnnotations;

namespace Application.VacationRental.Booking.DTO.Request
{
    public class RentalBindingModelRequest
    {
        [Required]
        public int Units { get; set; }

        public int PreparationTimeInDays { get; set; }
    }
}
