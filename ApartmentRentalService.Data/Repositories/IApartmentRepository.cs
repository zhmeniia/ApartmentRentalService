using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Repositories
{
    public interface IApartmentRepository
    {
        void Create(Apartment appartment);
        Apartment Get(int id);
        List<Apartment> GetAppartments();
    }
}
