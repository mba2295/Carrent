namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedYearTableAddedDirectField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "yearId", "dbo.Years");
            DropIndex("dbo.Cars", new[] { "yearId" });
            AddColumn("dbo.Cars", "carYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cars", "yearId");
            DropTable("dbo.Years");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        yearId = c.Int(nullable: false, identity: true),
                        year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.yearId);
            
            AddColumn("dbo.Cars", "yearId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "carYear");
            CreateIndex("dbo.Cars", "yearId");
            AddForeignKey("dbo.Cars", "yearId", "dbo.Years", "yearId", cascadeDelete: true);
        }
    }
}
