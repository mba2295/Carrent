namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSubscribeLetterAndMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        signUpFee = c.Short(nullable: false),
                        durationInMonths = c.Short(nullable: false),
                        discountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Customers", "subscribedNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "membershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "membershipTypeId");
            AddForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            DropColumn("dbo.Customers", "membershipTypeId");
            DropColumn("dbo.Customers", "subscribedNewsLetter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
