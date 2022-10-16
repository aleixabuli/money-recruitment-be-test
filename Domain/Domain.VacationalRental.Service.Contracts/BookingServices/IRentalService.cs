﻿using System.Threading.Tasks;
using Domain.VacationalRental.Model.BookingModel;

namespace Domain.VacationalRental.Service.Contracts.BookingServices
{
    public interface IRentalService
    {
        Task<Rental> GetById(int rentalId);
        Task<Rental> VerifyById(int rentalId);
    }
}
