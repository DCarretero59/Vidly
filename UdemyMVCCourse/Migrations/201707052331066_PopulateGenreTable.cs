namespace UdemyMVCCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Family')");
            Sql("INSERT INTO Genres(Name) VALUES('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES('Drama')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Name IN ('Comedy', 'Action', 'Family', 'Romance', 'Drama') ");
        }
    }
}
