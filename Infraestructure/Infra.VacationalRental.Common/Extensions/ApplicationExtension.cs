using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Response;
using Application.VacationRental.Booking.Mapper;
using Application.VacationRental.Booking.UseCase;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.VacationalRental.Common.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationDependencyInjection (this IServiceCollection services)
        {
            services
                .AddTransient<IGetBooking, GetBooking>()
                .AddTransient<IMapperApplication<Domain.VacationalRental.Model.BookingModel.Booking, BookingViewModelResponse>, BookingToBookingViewModelResponse>();

            return services;
        }
    }
}
