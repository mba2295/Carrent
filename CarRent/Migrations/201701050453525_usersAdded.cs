namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class usersAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85f779c5-2b52-4873-920d-b9437fe36550', N'guest@carrent.com', 0, N'ANtmT5OB7o811xRBz0qGnXSDMuGCXbhaZQLOos3V3ExbY6y7wKIvzGOwXKZcEiBrCQ==', N'0b9f4b6b-cc23-4a27-a584-8e62dbe2ee4e', NULL, 0, 0, NULL, 1, 0, N'guest@carrent.com')

              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cb532b02-b7e2-40d3-b866-fd96cd8acabc', N'admin@carrent.com', 0, N'AOyLluFJc0DLBhvZk94bM9iaucj6zb5nCSZtUxh+7p9vmlzTuIRa0kVeNrOJE9DpYA==', N'58a645d8-1004-4206-80c6-774f7a682748', NULL, 0, 0, NULL, 1, 0, N'admin@carrent.com')

              INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1b9f3139-b258-485a-9a76-b854f069221c', N'CanAddCars')

              INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cb532b02-b7e2-40d3-b866-fd96cd8acabc', N'1b9f3139-b258-485a-9a76-b854f069221c')

");
        }

        public override void Down()
        {
        }
    }
}
