namespace UdemyMVCCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7bffa577-f623-4d98-a9f9-04bd10f8327c', N'admin@vidly.com', 0, N'AAqMGEJUmNpWej7V6KXqsPW+agV/2PXGg3A35CDlHuydjbYgMG7acRrKSScuWjXVuQ==', N'8078a786-77a1-4578-9f1d-8c5628baf6e1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com');" +
                "INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7bffa577-f623-4d98-a9f9-04bd10f8328c', N'admin@vidly.com', 0, N'AAqMGEJUmNpWej7V6KXqsPW+agV/2PXGg3A35CDlHuydjbYgMG7acRrKSScuWjXVuQ==', N'8078a786-77a1-4578-9f1d-8c5628baf6e1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com');" +
                "INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'96a28338-4e62-4016-812a-f28f70fd13a3', N'CanManageMovies');" +
                "INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7bffa577-f623-4d98-a9f9-04bd10f8327c', N'96a28338-4e62-4016-812a-f28f70fd13a3');");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[AspNetUsers] WHERE [Id] = N'7bffa577-f623-4d98-a9f9-04bd10f8327c;'" +
                "DELETE FROM [dbo].[AspNetUsers] WHERE [Id] = N'7bffa577-f623-4d98-a9f9-04bd10f8328c;'" +
                "DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'96a28338-4e62-4016-812a-f28f70fd13a3';" +
                "DELETE FROM WHERE [UserId] = N'7bffa577-f623-4d98-a9f9-04bd10f8327c' AND [RoleId] = N'96a28338-4e62-4016-812a-f28f70fd13a3' ;");
        }
    }
}
