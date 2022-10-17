using System;
using System.ComponentModel.DataAnnotations;

namespace Application.VacationRental.Booking.DTO.Request
{
    public class BookingBindingModelRequest
    {
        [Required]
        public int RentalId { get; set; }

        [Required]
        public DateTime Start
        {
            get => _startIgnoreTime;
            set => _startIgnoreTime = value.Date;
        }


        private DateTime _startIgnoreTime;

        [Required]
        public int Nights { get; set; }

        [Required]
        public int Unit { get; set; }
    }
}
