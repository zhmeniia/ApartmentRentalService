namespace ApartmentRentalService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadfgdh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Apartment", "Homeowner_Id", "dbo.Homeowner");
            DropIndex("dbo.Apartment", new[] { "Homeowner_Id" });
            AddColumn("dbo.Apartment", "HomeownerId", c => c.Int(nullable: false));
            DropColumn("dbo.Apartment", "Homeowner_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartment", "Homeowner_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Apartment", "HomeownerId");
            CreateIndex("dbo.Apartment", "Homeowner_Id");
            AddForeignKey("dbo.Apartment", "Homeowner_Id", "dbo.Homeowner", "Id", cascadeDelete: true);
        }
    }
}
