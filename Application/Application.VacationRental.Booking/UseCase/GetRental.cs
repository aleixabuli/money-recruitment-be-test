using Application.VacationalRental.Common.Mapper;
using Application.VacationRental.Booking.DTO.Response;
using Application.VacationRental.Booking.UseCaseContracts;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Application.VacationRental.Booking.UseCase
{
    public class GetRental : IGetRental
    {
        IRentalService _rentalService;
        private readonly IMapperApplication<Domain.VacationalRental.Model.BookingModel.Rental, RentalViewModelResponse> _mapperAplication;

        public GetRental(
            IRentalService rentalService,
            IMapperApplication<Domain.VacationalRental.Model.BookingModel.Rental, RentalViewModelResponse> mapperAplication
            )
        {
            _rentalService = rentalService;
            _mapperAplication = mapperAplication;
        }

        public async Task<RentalViewModelResponse> Execute(int rentalId)
        {
            var rental = await _rentalService.GetById(rentalId);
            if (rental is null)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                message.ReasonPhrase = "Rental not found";
                message.StatusCode = System.Net.HttpStatusCode.NotFound;
                throw new HttpResponseException(message);
            }

            var targetRental = _mapperAplication.Map(rental);

            return targetRental;
        }
    }
}
