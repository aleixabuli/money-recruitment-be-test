﻿using System.Threading.Tasks;
using Application.VacationRental.Booking.DTO.Request;
using Application.VacationRental.Booking.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IGetRental _getRental;
        private readonly ICreateRental _createRental;

        public RentalsController(
            IGetRental getRental,
            ICreateRental createRental
            )
        {
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
        public async Task<ActionResult> Post(RentalBindingModelRequest rental)
        {
            var response = await _createRental.Execute(rental);

            return Ok(response);
        }
    }
}
