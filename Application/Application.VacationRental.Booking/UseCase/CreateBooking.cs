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
    public class CreateBooking : ICreateBooking
    {
        IBookingService _bookingService;
        IRentalService _rentalService;
        private readonly IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> _mapperAplication;

        public CreateBooking(
            IBookingService bookingService,
            IRentalService rentalService,
            IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> mapperAplication
            )
        {
            _bookingService = bookingService;
            _mapperAplication = mapperAplication;
            _rentalService = rentalService;
        }

        public async Task<BookingViewModelResponse> Execute(BookingBindingModelRequest newBookingRequest)
        {
            _bookingService.VerifyHasNights(newBookingRequest.Nights);

            await _rentalService.VerifyById(newBookingRequest.RentalId);

            await _bookingService.VerifyRentalUnitsAvailability(newBookingRequest.Nights, newBookingRequest.RentalId, newBookingRequest.Start);

            BookingViewModelResponse newBooking = (BookingViewModelResponse) await _bookingService.CreateBooking(
                newBookingRequest.Nights, 
                newBookingRequest.RentalId, 
                newBookingRequest.Start
                );

            return newBooking;
        }
    }
}
