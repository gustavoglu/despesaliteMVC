namespace Despesa.Lite.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoiddespesaVisita : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.visita", "id_despesa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.visita", "id_despesa", c => c.Guid(nullable: false));
        }
    }
}
