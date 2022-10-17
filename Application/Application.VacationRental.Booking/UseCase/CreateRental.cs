using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.DTO.Response;
using Application.VacationRental.Booking.UseCaseContracts;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Application.VacationRental.Booking.UseCase
{
    public class CreateRental : ICreateRental
    {
        IBookingService _bookingService;
        IRentalService _rentalService;
        private readonly IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> _mapperAplication;

        public CreateRental(
            IBookingService bookingService,
            IRentalService rentalService,
            IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> mapperAplication
            )
        {
            _bookingService = bookingService;
            _mapperAplication = mapperAplication;
            _rentalService = rentalService;
        }

        public async Task<RentalResourceIdViewModelResponse> Execute(RentalBindingModelRequest rental)
        {
            var result = (RentalResourceIdViewModelResponse) await _rentalService.CreateRental(
                rental.Units,
                rental.PreparationTimeInDays
                );

            return result;
        }
    }
}
