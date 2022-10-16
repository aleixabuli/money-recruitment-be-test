using Domain.VacationalRental.Service;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.VacationalRental.Common.Extensions
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependencyInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IBookingService, BookingService>()
                .AddTransient<IRentalService, RentalService>()
                ;

            return services;
        }
    }
}
