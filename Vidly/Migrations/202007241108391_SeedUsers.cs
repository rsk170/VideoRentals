namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cacb5f82-1178-4fe1-a556-a1126fbcd2e4', N'admin@vidly.com', 0, N'AH8ZcgJIZEmCtpB+eOng87jhCyhDvb+F+HNzdkLK53VGCql5K+Czl5tpX3rK0PhFDQ==', N'34603f7f-2915-4b84-88ef-b5ef94f64b44', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ffe75548-c46c-4c61-894f-a9f867a6f943', N'idk@gmail.com', 0, N'ABzHUgyINljLmApMoWYdbZW8Xk070JAiYMTC6EjCv50ED4R59DLuW5oDPLBpITyQkg==', N'1473c038-2be4-4aab-bf00-a46a9256c51c', NULL, 0, 0, NULL, 1, 0, N'idk@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'00574124-c594-47f9-9ca8-6246e353d458', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cacb5f82-1178-4fe1-a556-a1126fbcd2e4', N'00574124-c594-47f9-9ca8-6246e353d458')
               ");
        }

        public override void Down()
        {
        }
    }
}
