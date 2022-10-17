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

        public void Create(
            int keyId, 
            int units
            )
        {
            _rentals.Add(keyId, new RentalDB
            {
                Id = keyId,
                Units = units
            });
        }

        public void Create(
            int keyId,
            int units,
            int preparationInDays
            )
        {
            var rental = new RentalDB
            {
                Id = keyId,
                Units = units,
                PreparationTimeInDays = preparationInDays,
                OccupiedUnitsNumber = new Dictionary<int, bool>()
            };

            for (var i = 0; i < units; i++)
            {
                rental.OccupiedUnitsNumber.Add(i + 1, false);
            }

            _rentals.Add(
                keyId, 
                rental
                );
        }

        public async Task<IDictionary<int, Domain.VacationalRental.Model.BookingModel.Rental>> GetAll()
        {
            IDictionary<int, Domain.VacationalRental.Model.BookingModel.Rental> result = new Dictionary<int, Domain.VacationalRental.Model.BookingModel.Rental>();
            foreach (var booking in _rentals)
            {
                result.Add(booking.Key, _rentalMapper.MapToDomainModel(booking.Value));
            }

            return result;
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

        public async Task OccupyUnit(
            int rentalId, 
            int unit
            )
        {
            _rentals[rentalId].OccupiedUnitsNumber[unit] = true;
        }
    }
}
