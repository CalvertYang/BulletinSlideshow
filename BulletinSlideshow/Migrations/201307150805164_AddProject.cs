namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Situation = c.String(nullable: false),
                        Plan = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        LastUpdateOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
