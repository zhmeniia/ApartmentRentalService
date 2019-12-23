using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.EF
{
    class ApartmentContext : DbContext
    {
        public DbSet<Apartment> Apartments{ get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Homeowner> Homeowners { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Apartment>();

            modelBuilder.Entity<Homeowner>();

            modelBuilder.Entity<Tenant>();

            modelBuilder.Entity<Reservation>();
        }
    }
}
