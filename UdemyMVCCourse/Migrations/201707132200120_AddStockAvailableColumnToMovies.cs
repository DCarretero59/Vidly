namespace UdemyMVCCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockAvailableColumnToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET StockAvailable = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAvailable");
        }
    }
}
