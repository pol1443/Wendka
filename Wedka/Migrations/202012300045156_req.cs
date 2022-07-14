namespace Wedka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class req : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MapaModels", "opis", c => c.String(nullable: false));
            AlterColumn("dbo.MapaModels", "lat", c => c.String(nullable: false));
            AlterColumn("dbo.MapaModels", "lng", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MapaModels", "lng", c => c.String());
            AlterColumn("dbo.MapaModels", "lat", c => c.String());
            AlterColumn("dbo.MapaModels", "opis", c => c.String());
        }
    }
}
