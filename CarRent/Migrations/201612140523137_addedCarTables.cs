namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCarTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        carId = c.Int(nullable: false, identity: true),
                        manufacturerId = c.Int(nullable: false),
                        modelId = c.Int(nullable: false),
                        engineId = c.Int(nullable: false),
                        yearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.carId)
                .ForeignKey("dbo.Engines", t => t.engineId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.modelId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.yearId, cascadeDelete: true)
                .Index(t => t.manufacturerId)
                .Index(t => t.modelId)
                .Index(t => t.engineId)
                .Index(t => t.yearId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        engineId = c.Int(nullable: false, identity: true),
                        EngineName = c.String(maxLength: 150),
                        CC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.engineId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        manufacturerId = c.Int(nullable: false, identity: true),
                        manufacturerName = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.manufacturerId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        modelId = c.Int(nullable: false, identity: true),
                        modelName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.modelId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        yearId = c.Int(nullable: false, identity: true),
                        year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.yearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "yearId", "dbo.Years");
            DropForeignKey("dbo.Cars", "modelId", "dbo.Models");
            DropForeignKey("dbo.Cars", "manufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "engineId", "dbo.Engines");
            DropIndex("dbo.Cars", new[] { "yearId" });
            DropIndex("dbo.Cars", new[] { "engineId" });
            DropIndex("dbo.Cars", new[] { "modelId" });
            DropIndex("dbo.Cars", new[] { "manufacturerId" });
            DropTable("dbo.Years");
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Engines");
            DropTable("dbo.Cars");
        }
    }
}
