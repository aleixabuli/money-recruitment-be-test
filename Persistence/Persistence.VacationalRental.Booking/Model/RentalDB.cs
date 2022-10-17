using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.VacationalRental.Booking.Model
{
    public class RentalDB
    {
        public RentalDB()
        {
            
        }
        public int Id { get; set; }
        public int Units { get; set; }
        public int PreparationTimeInDays { get; set; }
        public Dictionary<int, bool> OccupiedUnitsNumber { get; set; }
    }
}
