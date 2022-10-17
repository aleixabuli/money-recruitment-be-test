using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VacationRental.Booking.Mapper
{
    public class BookingToBookingViewModelResponse : IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse>
    {
        public BookingViewModelResponse Map(Domain.VacationalRental.Model.BookingModel.Booking source)
        {
            return new BookingViewModelResponse()
            {
                Id = source.Id,
                Nights = source.Nights,
                RentalId = source.RentalId,
                Start = source.Start
            };
        }
    }
}
