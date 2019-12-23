namespace ApartmentRentalService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Appartment", newName: "Apartment");
            AddColumn("dbo.Reservation", "StartTime_Month", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "StartTime_Year", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "EndTime_Month", c => c.Int(nullable: false));
            AddColumn("dbo.Reservation", "EndTime_Year", c => c.Int(nullable: false));
            DropColumn("dbo.Reservation", "StartTime");
            DropColumn("dbo.Reservation", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservation", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservation", "EndTime_Year");
            DropColumn("dbo.Reservation", "EndTime_Month");
            DropColumn("dbo.Reservation", "StartTime_Year");
            DropColumn("dbo.Reservation", "StartTime_Month");
            RenameTable(name: "dbo.Apartment", newName: "Appartment");
        }
    }
}
