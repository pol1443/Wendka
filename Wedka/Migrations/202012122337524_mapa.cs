namespace Wedka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MapaModels", "tytul", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MapaModels", "tytul", c => c.String());
        }
    }
}
