namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyLastUpdateTimeColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Information", "LastUpdateOn", c => c.DateTime());
            AlterColumn("dbo.Members", "LastLoginOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastLoginOn", c => c.DateTime());
            AlterColumn("dbo.Information", "LastUpdateOn", c => c.DateTime());
        }
    }
}
