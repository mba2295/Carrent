namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNIC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NIC", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NIC");
        }
    }
}
