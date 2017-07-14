namespace UdemyMVCCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id IN (1,2,3,4)");
        }
    }
}