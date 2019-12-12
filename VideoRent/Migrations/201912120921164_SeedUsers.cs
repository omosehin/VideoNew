namespace VideoRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10223d53-7e05-4b12-ae9f-2b7c8245bc45', N'admin@vidly.com', 0, N'AGM0ONgqOyX5gc1CHYJdUTlJ6kaVf+ML20mkoVsV4GC3xLDdOt0pQW4CbWHqbI7+oA==', N'd9ac870a-289f-4489-ae04-56a7dd053aef', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec16315d-7cc1-4904-92ee-af956c076e80', N'guest@vidly.com', 0, N'AKNULl1xrQQg4SL+DuHgFI3SczCS1Ux5ycgpCu/3Sjz5oqCfdESABZHMzT4Q6q1ibw==', N'7a74ba79-4a98-486b-928b-74a87bcae92b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd6b08126-8aff-4c1e-b15b-f33674e5561f', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'07b22a64-4ac3-4290-aab9-f3a63a953539', N'd6b08126-8aff-4c1e-b15b-f33674e5561f')

");
        }
        
        public override void Down()
        {
        }
    }
}
