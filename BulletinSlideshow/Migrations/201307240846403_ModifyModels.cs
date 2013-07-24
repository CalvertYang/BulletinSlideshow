namespace BulletinSlideshow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Information", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Information", "ModifierId", c => c.Int());
            AddColumn("dbo.Members", "Activate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ModifierId", c => c.Int());
            AddForeignKey("dbo.Information", "CreatorId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Information", "ModifierId", "dbo.Members", "Id");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ModifierId", "dbo.Members", "Id");
            CreateIndex("dbo.Information", "CreatorId");
            CreateIndex("dbo.Information", "ModifierId");
            CreateIndex("dbo.Projects", "CreatorId");
            CreateIndex("dbo.Projects", "ModifierId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "ModifierId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.Information", new[] { "ModifierId" });
            DropIndex("dbo.Information", new[] { "CreatorId" });
            DropForeignKey("dbo.Projects", "ModifierId", "dbo.Members");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.Members");
            DropForeignKey("dbo.Information", "ModifierId", "dbo.Members");
            DropForeignKey("dbo.Information", "CreatorId", "dbo.Members");
            DropColumn("dbo.Projects", "ModifierId");
            DropColumn("dbo.Projects", "CreatorId");
            DropColumn("dbo.Members", "Activate");
            DropColumn("dbo.Information", "ModifierId");
            DropColumn("dbo.Information", "CreatorId");
        }
    }
}
