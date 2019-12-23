using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void Create(Reservation reservation)
        {
            using (var context = new ApartmentContext())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        public Reservation Get(int id)
        {
            using (var context = new ApartmentContext())
            {
                return context.Reservations.FirstOrDefault(r => r.Id == id);
            }
        }

        public List<Reservation> GetReservations()
        {
            using (var context = new ApartmentContext())
            {
                return context.Reservations.ToList();
            }
        }

        public void Update(Reservation reservation)
        {
            using (var context = new ApartmentContext())
            {
                context.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
