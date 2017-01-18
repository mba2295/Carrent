namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (id,signUpFee,durationInMonths,discountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (id,signUpFee,durationInMonths,discountRate) VALUES (2,2000,1,5)");
            Sql("INSERT INTO MembershipTypes (id,signUpFee,durationInMonths,discountRate) VALUES (3,10000,6,15)");
            Sql("INSERT INTO MembershipTypes (id,signUpFee,durationInMonths,discountRate) VALUES (4,20000,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
