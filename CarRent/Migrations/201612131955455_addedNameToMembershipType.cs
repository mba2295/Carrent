namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "name");
        }
    }
}
