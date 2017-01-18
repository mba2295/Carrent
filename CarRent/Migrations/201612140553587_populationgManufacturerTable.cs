namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class populationgManufacturerTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Toyota')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Suzuki')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Daihatsu')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Honda')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Nissan')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Mitsubishi')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('Lexus')");
            Sql("INSERT INTO Manufacturers (manufacturerName) VALUES('BMW')");


        }

        public override void Down()
        {
        }
    }
}
