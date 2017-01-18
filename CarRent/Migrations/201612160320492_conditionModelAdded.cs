namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conditionModelAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "modelId", "dbo.Models");
            DropIndex("dbo.Cars", new[] { "modelId" });
            AddColumn("dbo.Cars", "model", c => c.String());
            DropColumn("dbo.Cars", "modelId");          
            DropTable("dbo.Models");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        modelId = c.Int(nullable: false, identity: true),
                        modelName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.modelId);
            
            AddColumn("dbo.Engines", "EngineName", c => c.String());
            AddColumn("dbo.Cars", "modelId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "model");
            CreateIndex("dbo.Cars", "modelId");
            AddForeignKey("dbo.Cars", "modelId", "dbo.Models", "modelId", cascadeDelete: true);
        }
    }
}
