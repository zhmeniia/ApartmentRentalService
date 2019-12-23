namespace ApartmentRentalService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadfsdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomsCount = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        Description = c.String(),
                        MonthlyFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Homeowner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Homeowner", t => t.Homeowner_Id, cascadeDelete: true)
                .Index(t => t.Homeowner_Id);
            
            CreateTable(
                "dbo.Homeowner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime_Month = c.Int(nullable: false),
                        StartTime_Year = c.Int(nullable: false),
                        EndTime_Month = c.Int(nullable: false),
                        EndTime_Year = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AppartmentId = c.Int(nullable: false),
                        TenantStrarsCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        IsPremiumTenant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartment", "Homeowner_Id", "dbo.Homeowner");
            DropIndex("dbo.Apartment", new[] { "Homeowner_Id" });
            DropTable("dbo.Tenant");
            DropTable("dbo.Reservation");
            DropTable("dbo.Homeowner");
            DropTable("dbo.Apartment");
        }
    }
}
