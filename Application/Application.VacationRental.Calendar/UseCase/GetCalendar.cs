using Application.VacationRental.Calendar.DTO.Response;
using Application.VacationRental.Calendar.UseCaseContracts;
using Domain.VacationalRental.Service.Contracts.BookingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VacationRental.Calendar.UseCase
{
    public class GetCalendar : IGetCalendar
    {
        private readonly IBookingService _bookingService;
        private readonly IRentalService _rentalService;

        public GetCalendar(
            IBookingService bookingService,
            IRentalService rentalService
            )
        {
            _bookingService = bookingService;
            _rentalService = rentalService;
        }
        public async Task<CalendarViewModelResponse> Execute(
            int rentalId, 
            DateTime start, 
            int nights
            )
        {
            _bookingService.VerifyHasNights(nights);

            await _rentalService.VerifyById(rentalId);

            var actualRental = await _rentalService.GetById(rentalId);
            var allBookings = await _bookingService.GetAll();

            var result = new CalendarViewModelResponse
            {
                RentalId = rentalId,
                Dates = new List<CalendarDateViewModelResponse>()
            };

            //THIS double foreach structure (and the previous GetAll function call) are VERY inefficient.
            //In an environment that we have a database, the result
            //value will be extracted directly using a single query from the database, 
            //so this will be the fastest way to get all the required data
            
            CalendarDateViewModelResponse dateToAddToResult = null;
            var unitIsCleaned = false;
            for (var numberOfNights = 0; numberOfNights < nights; numberOfNights++)
            {
                if(dateToAddToResult is null || !unitIsCleaned)
                {
                    dateToAddToResult = new CalendarDateViewModelResponse
                    {
                        Date = start.Date.AddDays(numberOfNights),
                        Bookings = new List<CalendarBookingViewModelResponse>(),
                        PreparationTimes = new List<PreparationTimesResponse>()
                    };
                }
                else if (unitIsCleaned)
                {
                    unitIsCleaned = false;
                }

                var bookingsFiltered = allBookings.Values.Where(b =>
                    b.RentalId == rentalId
                    && b.Start <= dateToAddToResult.Date 
                    && b.Start.AddDays(b.Nights) > dateToAddToResult.Date
                    ).OrderBy(b => b.Unit);

                
                foreach (var booking in bookingsFiltered)
                {
                    dateToAddToResult.Bookings.Add(new CalendarBookingViewModelResponse
                    {
                        Id = booking.Id,
                        Unit = booking.Unit
                    });
                }

                result.Dates.Add(dateToAddToResult);
            }

            //build PreparationTimes structure
            CalendarDateViewModelResponse[] resultDatesCopy = new CalendarDateViewModelResponse[result.Dates.Count];
            result.Dates.CopyTo(resultDatesCopy);
            
            CalendarDateViewModelResponse yesterdayDate = null;
            int index = 0;
            
            foreach (var actualDate in resultDatesCopy)
            {
                if (yesterdayDate is null)
                {
                    //first iteration
                    yesterdayDate = actualDate;
                }
                else
                {
                    //the rest of iterations
                    
                    foreach (var yesterdayBooking in yesterdayDate.Bookings)
                    {
                        if(actualDate.Bookings.FirstOrDefault(b => b.Unit== yesterdayBooking.Unit) == null)
                        {
                            //The Unit is not now occupied, so it must to be cleaned.
                            //We inform the Unit to preparate
                            for (int prepDays = 0; prepDays < actualRental.PreparationTimeInDays; prepDays++)
                            {
                                if((index + prepDays) < result.Dates.Count())
                                {
                                    result.Dates[index + prepDays].PreparationTimes.Add(
                                        new PreparationTimesResponse() { Unit = yesterdayBooking.Unit });
                                }
                                
                            }
                        }

                    }
                }


                yesterdayDate = actualDate;
                index++;
            }



            return result;
        }
    }
}
