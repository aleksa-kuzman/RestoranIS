namespace Restoran.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_users_and_roles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bfe7b81b-d33d-4eb6-9b3a-c23438cee70c', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'981d1620-d408-4e55-9f66-8ddf6584c46a', N'Konobar')


INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'832a0b4b-ab88-4a91-86e5-e76bcd25246a', N'Aleksa@aleksa.com', 0, N'ACx8AnQTeoGEX547/vRL1WrAGS8jmvt64wNzvxQEH73Zfj89Ih3nP5rOwT2y95jtUg==', N'cce66b1a-ad79-4635-88d8-2dc808055c34', NULL, 0, 0, NULL, 1, 0, N'Aleksa@aleksa.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd7b7417c-c679-4220-94b4-ec9033ddbe8e', N'Konobar@konobar.com', 0, N'AOJNe7nmt9+CY2VPs5rJ9CmKmKLZ2mlvLKbsR313ILJEgKOrlu7djAU2/iHgjDx61g==', N'7139c18a-af20-4325-84a1-e16976121b5d', NULL, 0, 0, NULL, 1, 0, N'Konobar@konobar.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f89245c0-163e-46e0-a1d6-9aa73fbabe3c', N'Admin@admin.com', 0, N'AJf+q05bc3HGYmaDG/bXISdJFZDFL6e3L6cQeUA/ZOTVP5MwaT5oZ8TaGM5Lz0z0dw==', N'53cea693-c91e-45ac-997d-e9c191888f75', NULL, 0, 0, NULL, 1, 0, N'Admin@admin.com')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd7b7417c-c679-4220-94b4-ec9033ddbe8e', N'981d1620-d408-4e55-9f66-8ddf6584c46a')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f89245c0-163e-46e0-a1d6-9aa73fbabe3c', N'bfe7b81b-d33d-4eb6-9b3a-c23438cee70c')


");
        }
        
        public override void Down()
        {
        }
    }
}
