using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.EF.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        public void Create(Apartment appartment)
        {
            using (var context = new ApartmentContext())
            {
                context.Apartments.Add(appartment);
                context.SaveChanges();
            }
        }

        public Apartment Get(int id)
        {
            using (var context = new ApartmentContext())
            {
                return context.Apartments.FirstOrDefault(a => a.Id == id);
            }
        }

        public List<Apartment> GetAppartments()
        {
            using (var context = new ApartmentContext())
            {
                return context.Apartments.ToList();
            }
        }
    }
}
