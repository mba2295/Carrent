namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populationgModelTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Models (modelName) VALUES('Corolla')");
            Sql("INSERT INTO Models (modelName) VALUES('Baleno')");
            Sql("INSERT INTO Models (modelName) VALUES('Coure')");
            Sql("INSERT INTO Models (modelName) VALUES('Civic')");
            Sql("INSERT INTO Models (modelName) VALUES('Sunny')");
        }
        
        public override void Down()
        {
        }
    }
}
