namespace Wedka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pierwsxza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtykolModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.String(),
                        name = c.String(),
                        zdjecieProfilowe = c.String(),
                        zdjecia = c.String(),
                        kiedyNapisane = c.DateTime(nullable: false),
                        komentarze = c.String(),
                        temat = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.KomentarzModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.String(nullable: false),
                        postId = c.Int(nullable: false),
                        kiedyNapisane = c.DateTime(nullable: false),
                        komentarze = c.String(nullable: false),
                        zdjecie1 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.String(nullable: false),
                        kiedyNapisane = c.DateTime(nullable: false),
                        post = c.String(nullable: false),
                        kategoria = c.String(nullable: false),
                        zdjecie1 = c.String(),
                        zdjecie2 = c.String(),
                        zdjecie3 = c.String(),
                        zdjecie4 = c.String(),
                        iloscKom = c.String(),
                        temat = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.AspNetUsers", "zalozenie", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "opis", c => c.String());
            AddColumn("dbo.AspNetUsers", "nazwaUzytkownika", c => c.String());
            AddColumn("dbo.AspNetUsers", "Cytat", c => c.String());
            AddColumn("dbo.AspNetUsers", "zdjecieProfilowe", c => c.String());
            AddColumn("dbo.AspNetUsers", "lokacja", c => c.String());
            AddColumn("dbo.AspNetUsers", "lokacja2", c => c.String());
            AddColumn("dbo.AspNetUsers", "ostatnieLogowanie", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "szerokosc", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "dlugosc", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "admin", c => c.String());
            AddColumn("dbo.AspNetUsers", "punkty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "punkty");
            DropColumn("dbo.AspNetUsers", "admin");
            DropColumn("dbo.AspNetUsers", "dlugosc");
            DropColumn("dbo.AspNetUsers", "szerokosc");
            DropColumn("dbo.AspNetUsers", "ostatnieLogowanie");
            DropColumn("dbo.AspNetUsers", "lokacja2");
            DropColumn("dbo.AspNetUsers", "lokacja");
            DropColumn("dbo.AspNetUsers", "zdjecieProfilowe");
            DropColumn("dbo.AspNetUsers", "Cytat");
            DropColumn("dbo.AspNetUsers", "nazwaUzytkownika");
            DropColumn("dbo.AspNetUsers", "opis");
            DropColumn("dbo.AspNetUsers", "zalozenie");
            DropTable("dbo.PostModels");
            DropTable("dbo.KomentarzModels");
            DropTable("dbo.ArtykolModels");
        }
    }
}
