namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlideInterval : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SlideInterval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parameters");
        }
    }
}
