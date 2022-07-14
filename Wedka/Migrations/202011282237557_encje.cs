namespace Wedka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class encje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KomentarzModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.KomentarzModels", "PostModel_Id", c => c.Int());
            AddColumn("dbo.PostModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.KomentarzModels", "ApplicationUser_Id");
            CreateIndex("dbo.KomentarzModels", "PostModel_Id");
            CreateIndex("dbo.PostModels", "ApplicationUser_Id");
            AddForeignKey("dbo.KomentarzModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PostModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.KomentarzModels", "PostModel_Id", "dbo.PostModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KomentarzModels", "PostModel_Id", "dbo.PostModels");
            DropForeignKey("dbo.PostModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.KomentarzModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PostModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.KomentarzModels", new[] { "PostModel_Id" });
            DropIndex("dbo.KomentarzModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.PostModels", "ApplicationUser_Id");
            DropColumn("dbo.KomentarzModels", "PostModel_Id");
            DropColumn("dbo.KomentarzModels", "ApplicationUser_Id");
        }
    }
}
