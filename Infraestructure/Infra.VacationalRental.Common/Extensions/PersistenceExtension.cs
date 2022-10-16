using Domain.VacationalRental.Repository.Contracts.Booking;
using Microsoft.Extensions.DependencyInjection;
using Persistence.VacationalRental.Booking.Mapper;
using Persistence.VacationalRental.Booking.Model;
using Persistence.VacationalRental.Booking.Repository;
using Persistence.VacationalRental.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.VacationalRental.Common.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistenceDependencyInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IBookingRepository, BookingRepository>()
                .AddTransient<IRentalRepository, RentalRepository>()

                .AddTransient<IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Booking, BookingDB>,BookingMapper>()
                .AddTransient<IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Rental, RentalDB>, RentalMapper>()

                //.AddSingleton<IDictionary<int, RentalViewModel>>(new Dictionary<int, RentalViewModel>())
                //.AddSingleton<IDictionary<int, BookingViewModelResponse>>(new Dictionary<int, BookingViewModelResponse>())
                .AddSingleton<IDictionary<int, RentalDB>>(new Dictionary<int, RentalDB>())
                .AddSingleton<IDictionary<int, BookingDB>>(new Dictionary<int, BookingDB>())
            ;

            return services;
        }
    }
}
