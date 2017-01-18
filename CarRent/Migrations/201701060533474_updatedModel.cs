namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModel : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Cars DROP CONSTRAINT DF__Cars__Available__0697FACD");
            AlterColumn("dbo.Cars", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Available", c => c.Byte(nullable: false));
        }
    }
}
