namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conditionAddedToCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        conditionId = c.Int(nullable: false, identity: true),
                        condtion = c.String(),
                    })
                .PrimaryKey(t => t.conditionId);
            
            AddColumn("dbo.Cars", "conditionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "conditionId");
            AddForeignKey("dbo.Cars", "conditionId", "dbo.Conditions", "conditionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "conditionId", "dbo.Conditions");
            DropIndex("dbo.Cars", new[] { "conditionId" });
            DropColumn("dbo.Cars", "conditionId");
            DropTable("dbo.Conditions");
        }
    }
}
