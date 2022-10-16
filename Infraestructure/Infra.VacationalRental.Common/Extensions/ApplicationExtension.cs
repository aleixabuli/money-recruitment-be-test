using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Response;
using Application.VacationRental.Booking.Mapper;
using Application.VacationRental.Booking.UseCase;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.VacationalRental.Common.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationDependencyInjection (this IServiceCollection services)
        {
            services
                .AddTransient<IGetBooking, GetBooking>()
                .AddTransient<ICreateBooking, CreateBooking>()
                .AddTransient<IGetRental, GetRental>()
                .AddTransient<ICreateRental, CreateRental>()

                .AddTransient<IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse>, BookingToBookingViewModelResponse>()
                .AddTransient<IMapperApplication<Domain.VacationalRental.Model.BookingModel.Rental, RentalViewModelResponse>, RentalToRentalViewModelResponse>();
            ;

            return services;
        }
    }
}
