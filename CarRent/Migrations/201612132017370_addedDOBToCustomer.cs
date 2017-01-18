namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDOBToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "dob", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "dob");
        }
    }
}
