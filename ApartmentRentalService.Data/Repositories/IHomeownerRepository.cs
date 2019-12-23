using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Repositories
{
    public interface IHomeownerRepository
    {
        void Create(Homeowner homeowner);
        Homeowner Get(int id);
        List<Homeowner> GetHomeowners();
    }
}
