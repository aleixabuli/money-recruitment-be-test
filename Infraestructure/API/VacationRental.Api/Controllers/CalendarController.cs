using System;
using System.Threading.Tasks;
using Application.VacationRental.Calendar.UseCaseContracts;
using Microsoft.AspNetCore.Mvc;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IGetCalendar _getCalendar;

        public CalendarController(
            IGetCalendar getCalendar
            )
        {
            _getCalendar = getCalendar;
        }

        /// <summary>
        /// Gets the calendar filtered by the RentalId, Start date and the number of nights
        /// </summary>
        /// <param name="rentalId">Reference of the rental</param>
        /// <param name="start">Starting date to filter the calendar</param>
        /// <param name="nights">Number of the nights to show on the calendar</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get(
            int rentalId,
            DateTime start,
            int nights
            )
        {
            var result = await _getCalendar.Execute(
                rentalId,
                start,
                nights
                );
            
            return Ok(result);
        }
    }
}
