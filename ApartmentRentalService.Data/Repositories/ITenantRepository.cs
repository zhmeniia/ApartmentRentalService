using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Repositories
{
    public interface ITenantRepository
    {
        void Create(Tenant tenant);
        void Update(Tenant tenant);
        Tenant Get(int id);
        List<Tenant> GetTenants();
    }
}
