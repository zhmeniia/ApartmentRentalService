namespace ApartmentRentalService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomsCount = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        Description = c.String(),
                        Homeowner_Name = c.String(),
                        Homeowner_Surname = c.String(),
                        Homeowner_PhoneNumber = c.String(),
                        MonthlyFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AppartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenant");
            DropTable("dbo.Reservation");
            DropTable("dbo.Appartment");
        }
    }
}
