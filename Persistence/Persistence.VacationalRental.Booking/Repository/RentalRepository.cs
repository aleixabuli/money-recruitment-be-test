using Domain.VacationalRental.Repository.Contracts.Booking;
using Persistence.VacationalRental.Booking.Model;
using Persistence.VacationalRental.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.VacationalRental.Booking.Repository
{
    public class RentalRepository : IRentalRepository
    {
        
        private readonly IDictionary<int, RentalDB> _rentals;
        IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Rental, RentalDB> _rentalMapper;
        public RentalRepository(
            IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Rental, RentalDB> rentalMapper,
            IDictionary<int, RentalDB> rentals
            )
        {
            _rentalMapper = rentalMapper;
            _rentals = rentals;
        }

        public async Task<Domain.VacationalRental.Model.BookingModel.Rental> GetById(int rentalId)
        {
            if (!_rentals.ContainsKey(rentalId))
            {
                return null;
            }
            var bookingTarget = _rentalMapper.MapToDomainModel(_rentals[rentalId]);
            return bookingTarget;
        }
    }
}
