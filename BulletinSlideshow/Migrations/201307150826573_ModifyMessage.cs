namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "NotifyMessage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "NotifyMessage", c => c.String());
        }
    }
}
