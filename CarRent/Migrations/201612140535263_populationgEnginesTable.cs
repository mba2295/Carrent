namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populationgEnginesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ENGINES (CC) VALUES(800)");
            Sql("INSERT INTO ENGINES (CC) VALUES(1000)");
            Sql("INSERT INTO ENGINES (CC) VALUES(1300)");
            Sql("INSERT INTO ENGINES (CC) VALUES(1600)");
            Sql("INSERT INTO ENGINES (CC) VALUES(1800)");
            Sql("INSERT INTO ENGINES (CC) VALUES(1800)");
            Sql("INSERT INTO ENGINES (CC) VALUES(2000)");
            Sql("INSERT INTO ENGINES (CC) VALUES(2400)");
            Sql("INSERT INTO ENGINES (CC) VALUES(3000)");
            Sql("INSERT INTO ENGINES (CC) VALUES(4000)");
            Sql("INSERT INTO ENGINES (CC) VALUES(5000)");

        }

        public override void Down()
        {
        }
    }
}
