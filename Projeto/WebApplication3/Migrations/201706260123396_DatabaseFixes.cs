namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId", "dbo.ProfileModels");
            DropForeignKey("dbo.PostComentaryModels", "PostModel_PostId", "dbo.PostModels");
            DropIndex("dbo.PostComentaryModels", new[] { "PostComentaryCreator_ProfileId" });
            DropIndex("dbo.PostComentaryModels", new[] { "PostModel_PostId" });
            RenameColumn(table: "dbo.PostModels", name: "PostCreator_ProfileId", newName: "ProfileModel_ProfileId");
            RenameIndex(table: "dbo.PostModels", name: "IX_PostCreator_ProfileId", newName: "IX_ProfileModel_ProfileId");
            CreateTable(
                "dbo.PostModelPostComentaryModels",
                c => new
                    {
                        PostModel_PostId = c.Guid(nullable: false),
                        PostComentaryModel_PostComentaryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostModel_PostId, t.PostComentaryModel_PostComentaryId })
                .ForeignKey("dbo.PostModels", t => t.PostModel_PostId, cascadeDelete: true)
                .ForeignKey("dbo.PostComentaryModels", t => t.PostComentaryModel_PostComentaryId, cascadeDelete: true)
                .Index(t => t.PostModel_PostId)
                .Index(t => t.PostComentaryModel_PostComentaryId);
            
            AddColumn("dbo.PostModels", "PostCreator", c => c.String());
            AddColumn("dbo.PostComentaryModels", "PostComentaryCreator", c => c.String());
            DropColumn("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId");
            DropColumn("dbo.PostComentaryModels", "PostModel_PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostComentaryModels", "PostModel_PostId", c => c.Guid());
            AddColumn("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId", c => c.Guid());
            DropForeignKey("dbo.PostModelPostComentaryModels", "PostComentaryModel_PostComentaryId", "dbo.PostComentaryModels");
            DropForeignKey("dbo.PostModelPostComentaryModels", "PostModel_PostId", "dbo.PostModels");
            DropIndex("dbo.PostModelPostComentaryModels", new[] { "PostComentaryModel_PostComentaryId" });
            DropIndex("dbo.PostModelPostComentaryModels", new[] { "PostModel_PostId" });
            DropColumn("dbo.PostComentaryModels", "PostComentaryCreator");
            DropColumn("dbo.PostModels", "PostCreator");
            DropTable("dbo.PostModelPostComentaryModels");
            RenameIndex(table: "dbo.PostModels", name: "IX_ProfileModel_ProfileId", newName: "IX_PostCreator_ProfileId");
            RenameColumn(table: "dbo.PostModels", name: "ProfileModel_ProfileId", newName: "PostCreator_ProfileId");
            CreateIndex("dbo.PostComentaryModels", "PostModel_PostId");
            CreateIndex("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId");
            AddForeignKey("dbo.PostComentaryModels", "PostModel_PostId", "dbo.PostModels", "PostId");
            AddForeignKey("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId", "dbo.ProfileModels", "ProfileId");
        }
    }
}
