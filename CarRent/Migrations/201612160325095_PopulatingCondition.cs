namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingCondition : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Conditions (condtion) VALUES('Average')");
            Sql("INSERT INTO Conditions (condtion) VALUES('Good')");
            Sql("INSERT INTO Conditions (condtion) VALUES('Encellent')");

        }

        public override void Down()
        {
        }
    }
}
