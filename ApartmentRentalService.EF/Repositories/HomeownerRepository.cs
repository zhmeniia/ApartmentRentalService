using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.EF.Repositories
{
    public class HomeownerRepository : IHomeownerRepository
    {
        public void Create(Homeowner homeowner)
        {
            using (var context = new ApartmentContext())
            {
                context.Homeowners.Add(homeowner);
                context.SaveChanges();
            }
        }

        public Homeowner Get(int id)
        {
            using (var context = new ApartmentContext())
            {
                return context.Homeowners.FirstOrDefault(h => h.Id == id);
            }
        }

        public List<Homeowner> GetHomeowners()
        {
            using (var context = new ApartmentContext())
            {
                return context.Homeowners.ToList();
            }
        }
    }
}
