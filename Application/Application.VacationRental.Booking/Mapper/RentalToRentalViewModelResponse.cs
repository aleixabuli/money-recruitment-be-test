using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.VacationRental.Booking.Mapper
{
    public class RentalToRentalViewModelResponse : IMapperApplication<Domain.VacationalRental.Model.BookingModel.Rental, RentalViewModelResponse>
    {
        public RentalViewModelResponse Map(Domain.VacationalRental.Model.BookingModel.Rental source)
        {
            return new RentalViewModelResponse()
            {
                Id = source.Id,
                Units = source.Units
            };
        }
    }
}
