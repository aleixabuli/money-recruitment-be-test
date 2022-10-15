using System;
using Persistence.VacationalRental.Booking.Model;
using Persistence.VacationalRental.Common.Mapper;

namespace Persistence.VacationalRental.Booking.Mapper
{
    public class BookingMapper : IMapperPersistence<Domain.VacationalRental.Model.BookingModel.Booking, Model.BookingDB>
    {
        public BookingDB CreatePersistenceModel(Domain.VacationalRental.Model.BookingModel.Booking domain)
        {
            throw new NotImplementedException();
        }

        public Domain.VacationalRental.Model.BookingModel.Booking MapToDomainModel(BookingDB persistence)
        {
            Domain.VacationalRental.Model.BookingModel.Booking domainModel = new Domain.VacationalRental.Model.BookingModel.Booking()
            {
                Id = persistence.Id,
                Nights = persistence.Nights,
                RentalId = persistence.RentalId,
                Start = persistence.Start
            };

            return domainModel;
        }

        public void MapToPersistenceModel(Domain.VacationalRental.Model.BookingModel.Booking domain, BookingDB persistence)
        {
            throw new NotImplementedException();
        }
    }
}
