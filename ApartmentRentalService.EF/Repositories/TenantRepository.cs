using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.EF.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        public void Create(Tenant tenant)
        {
            using (var context = new ApartmentContext())
            {
                context.Tenants.Add(tenant);
                context.SaveChanges();
            }
        }

        public Tenant Get(int id)
        {
            using (var context = new ApartmentContext())
            {
                return context.Tenants.FirstOrDefault(t => t.Id == id);
            }
        }

        public List<Tenant> GetTenants()
        {
            using (var context = new ApartmentContext())
            {
                return context.Tenants.ToList();
            }
        }

        public void Update(Tenant tenant)
        {
            using (var context = new ApartmentContext())
            {
                context.Entry(tenant).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
