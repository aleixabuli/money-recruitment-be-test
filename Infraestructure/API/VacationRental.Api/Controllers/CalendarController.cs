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
