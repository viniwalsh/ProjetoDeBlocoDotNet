namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileModels",
                c => new
                    {
                        ProfileId = c.Guid(nullable: false),
                        ProfileLoginId = c.String(),
                        ProfileUserName = c.String(),
                        ProfilePicture = c.String(),
                        ProfileGender = c.String(),
                        ProfileCreationTime = c.DateTime(nullable: false),
                        ProfileEmail = c.String(),
                        ProfileModel_ProfileId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.ProfileModels", t => t.ProfileModel_ProfileId)
                .Index(t => t.ProfileModel_ProfileId);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        PostDetails = c.String(),
                        PostPicture = c.String(),
                        PostLikes = c.Int(nullable: false),
                        PostCreator_ProfileId = c.Guid(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.ProfileModels", t => t.PostCreator_ProfileId)
                .Index(t => t.PostCreator_ProfileId);
            
            CreateTable(
                "dbo.PostComentaryModels",
                c => new
                    {
                        PostComentaryId = c.Guid(nullable: false),
                        PostComentaryContent = c.String(),
                        PostComentaryLikes = c.Int(nullable: false),
                        PostComentaryCreator_ProfileId = c.Guid(),
                        PostModel_PostId = c.Guid(),
                    })
                .PrimaryKey(t => t.PostComentaryId)
                .ForeignKey("dbo.ProfileModels", t => t.PostComentaryCreator_ProfileId)
                .ForeignKey("dbo.PostModels", t => t.PostModel_PostId)
                .Index(t => t.PostComentaryCreator_ProfileId)
                .Index(t => t.PostModel_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostModels", "PostCreator_ProfileId", "dbo.ProfileModels");
            DropForeignKey("dbo.PostComentaryModels", "PostModel_PostId", "dbo.PostModels");
            DropForeignKey("dbo.PostComentaryModels", "PostComentaryCreator_ProfileId", "dbo.ProfileModels");
            DropForeignKey("dbo.ProfileModels", "ProfileModel_ProfileId", "dbo.ProfileModels");
            DropIndex("dbo.PostComentaryModels", new[] { "PostModel_PostId" });
            DropIndex("dbo.PostComentaryModels", new[] { "PostComentaryCreator_ProfileId" });
            DropIndex("dbo.PostModels", new[] { "PostCreator_ProfileId" });
            DropIndex("dbo.ProfileModels", new[] { "ProfileModel_ProfileId" });
            DropTable("dbo.PostComentaryModels");
            DropTable("dbo.PostModels");
            DropTable("dbo.ProfileModels");
        }
    }
}
