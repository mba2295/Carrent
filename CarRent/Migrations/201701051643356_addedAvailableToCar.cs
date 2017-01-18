namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAvailableToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Available", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Available");
        }
    }
}
