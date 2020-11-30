namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostModels", "PostCreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.PostComentaryModels", "PostComentaryCreationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComentaryModels", "PostComentaryCreationTime");
            DropColumn("dbo.PostModels", "PostCreationTime");
        }
    }
}
