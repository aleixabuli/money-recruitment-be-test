using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        //private readonly IDictionary<int, RentalViewModel> _rentals;
        private readonly IGetRental _getRental;
        private readonly ICreateRental _createRental;

        public RentalsController(
            //IDictionary<int, RentalViewModel> rentals,
            IGetRental getRental,
            ICreateRental createRental
            )
        {
            //_rentals = rentals;
            _getRental = getRental;
            _createRental = createRental;
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public async Task<ActionResult> Get(int rentalId)
        {
            var rental = await _getRental.Execute(rentalId);

            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult> Post(RentalBindingModelRequest rental)//ResourceIdViewModel Post(RentalBindingModel model)
        {
            var response = await _createRental.Execute(rental);

            /*
            var key = new ResourceIdViewModel { Id = _rentals.Keys.Count + 1 };

            _rentals.Add(key.Id, new RentalViewModel
            {
                Id = key.Id,
                Units = model.Units
            });

            return key;
            */
            return Ok(response);
        }
    }
}
