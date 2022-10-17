using Application.VacationalRental.Common.Mapper;
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
    public class GetBooking : IGetBooking
    {
        IBookingService _bookingService;
        private readonly IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> _mapperAplication;

        public GetBooking(
            IBookingService bookingService,
            IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse> mapperAplication
            )
        {
            _bookingService = bookingService;
            _mapperAplication = mapperAplication;
        }

        public async Task<BookingViewModelResponse> Execute(int bookingId)
        {
            var booking = await _bookingService.GetById(bookingId);
            if (booking is null)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                message.ReasonPhrase = "Booking not found";
                message.StatusCode = System.Net.HttpStatusCode.NotFound;
                throw new HttpResponseException(message);
            }

            var targetBooking = _mapperAplication.Map(booking);

            return targetBooking;
        }
    }
}
