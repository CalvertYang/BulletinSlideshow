namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Information", "LastUpdateOn", c => c.DateTime());
            AlterColumn("dbo.Members", "LastLoginOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastLoginOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Information", "LastUpdateOn");
        }
    }
}
