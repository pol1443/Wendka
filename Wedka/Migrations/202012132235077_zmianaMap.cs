namespace Wedka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianaMap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MapaModels", "lat", c => c.String());
            AlterColumn("dbo.MapaModels", "lng", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MapaModels", "lng", c => c.Double(nullable: false));
            AlterColumn("dbo.MapaModels", "lat", c => c.Double(nullable: false));
        }
    }
}
