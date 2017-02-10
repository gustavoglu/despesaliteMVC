namespace Despesa.Lite.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cliente_usuarios", "CriadoEm", c => c.DateTime());
            AlterColumn("dbo.cliente_usuarios", "DeletadoEm", c => c.DateTime());
            AlterColumn("dbo.cliente_usuarios", "Ativo", c => c.Boolean());
            AlterColumn("dbo.cliente_usuarios", "Deletado", c => c.Boolean());
            AlterColumn("dbo.cliente", "CriadoEm", c => c.DateTime());
            AlterColumn("dbo.cliente", "DeletadoEm", c => c.DateTime());
            AlterColumn("dbo.cliente", "Ativo", c => c.Boolean());
            AlterColumn("dbo.cliente", "Deletado", c => c.Boolean());
            AlterColumn("dbo.visita", "CriadoEm", c => c.DateTime());
            AlterColumn("dbo.visita", "DeletadoEm", c => c.DateTime());
            AlterColumn("dbo.visita", "Ativo", c => c.Boolean());
            AlterColumn("dbo.visita", "Deletado", c => c.Boolean());
            AlterColumn("dbo.despesa", "CriadoEm", c => c.DateTime());
            AlterColumn("dbo.despesa", "DeletadoEm", c => c.DateTime());
            AlterColumn("dbo.despesa", "Ativo", c => c.Boolean());
            AlterColumn("dbo.despesa", "Deletado", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.despesa", "Deletado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.despesa", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.despesa", "DeletadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.despesa", "CriadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.visita", "Deletado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.visita", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.visita", "DeletadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.visita", "CriadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.cliente", "Deletado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cliente", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cliente", "DeletadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.cliente", "CriadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.cliente_usuarios", "Deletado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cliente_usuarios", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.cliente_usuarios", "DeletadoEm", c => c.DateTime(nullable: false));
            AlterColumn("dbo.cliente_usuarios", "CriadoEm", c => c.DateTime(nullable: false));
        }
    }
}
