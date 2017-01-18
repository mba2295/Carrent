namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRentedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Car_carId = c.Int(nullable: false),
                        Customer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_carId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .Index(t => t.Car_carId)
                .Index(t => t.Customer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Car_carId", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "Customer_id" });
            DropIndex("dbo.Rentals", new[] { "Car_carId" });
            DropTable("dbo.Rentals");
        }
    }
}
