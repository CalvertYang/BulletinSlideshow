namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpectSolveDateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ExpectSolveDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ExpectSolveDate");
        }
    }
}
