namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDoB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "dob", c => c.DateTime(nullable: false));
        }
    }
}
