using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VacationalRental.Model.BookingModel
{
    public class Rental
    {
        public int Id { get; set; }
        public int Units { get; set; }
        public int PreparationTimeInDays { get; set; }
        public Dictionary<int, bool> OccupiedUnitsNumber { get; set; }
    }
}
