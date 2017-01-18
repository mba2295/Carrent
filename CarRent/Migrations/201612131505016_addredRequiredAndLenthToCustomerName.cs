namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addredRequiredAndLenthToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "name", c => c.String());
        }
    }
}
