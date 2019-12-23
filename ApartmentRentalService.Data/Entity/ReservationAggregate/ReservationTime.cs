using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Entity
{
    public class ReservationTime
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public static bool operator >=(ReservationTime r1, ReservationTime r2)
        {
            if(r1.Year > r2.Year)
            {
                return true;
            }
            else if(r1.Year < r2.Year)
            {
                return false;
            }
            else
            {
                return r1.Month >= r2.Month;
            }
        }

        public static bool operator <=(ReservationTime r1, ReservationTime r2)
        {
            if (r1.Year < r2.Year)
            {
                return true;
            }
            else if (r1.Year > r2.Year)
            {
                return false;
            }
            else
            {
                return r1.Month <= r2.Month;
            }
        }
    }
}
