using Domain.VacationalRental.Model.BookingModel;
using Domain.VacationalRental.Repository.Contracts.Booking;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VacationalRental.Service
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Rental> GetById(int rentalId)
        {
            var rental = await _rentalRepository.GetById(rentalId);
            return rental;
        }

        public async Task<Rental> VerifyById(int rentalId)
        {
            var rental = await GetById(rentalId);
            
            if(rental is null)
            {
                throw new ApplicationException("Rental not found");
            }

            return rental;
        }
    }
}
