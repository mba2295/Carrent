namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEngineModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "model", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "model", c => c.String());
        }
    }
}
