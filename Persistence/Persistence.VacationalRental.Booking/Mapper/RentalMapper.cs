using System;
using Persistence.VacationalRental.Booking.Model;
using Persistence.VacationalRental.Common.Mapper;

namespace Persistence.VacationalRental.Booking.Mapper
{
    public class RentalMapper : IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Rental, Model.RentalDB>
    {
        public RentalDB CreatePersistenceModel(Domain.VacationalRental.Model.BookingModel.Rental domain)
        {
            throw new NotImplementedException();
        }

        public Domain.VacationalRental.Model.BookingModel.Rental MapToDomainModel(RentalDB persistence)
        {
            Domain.VacationalRental.Model.BookingModel.Rental domainModel = new Domain.VacationalRental.Model.BookingModel.Rental()
            {
                Id = persistence.Id,
                Units = persistence.Units
            };

            return domainModel;
        }

        public void MapToPersistenceModel(Domain.VacationalRental.Model.BookingModel.Rental domain, RentalDB persistence)
        {
            throw new NotImplementedException();
        }

    }
}
