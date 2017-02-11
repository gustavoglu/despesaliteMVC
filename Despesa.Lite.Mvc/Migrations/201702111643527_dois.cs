namespace Despesa.Lite.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dois : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.despesa_imagem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        id_despesa = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        imagem_link = c.String(nullable: false, maxLength: 1000, unicode: false),
                        CriadoPor = c.String(maxLength: 100, unicode: false),
                        DeletadoPor = c.String(maxLength: 100, unicode: false),
                        AtualizadoPor = c.String(maxLength: 100, unicode: false),
                        AtivadoPor = c.String(maxLength: 100, unicode: false),
                        DesativadoPor = c.String(maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(),
                        DeletadoEm = c.DateTime(),
                        Ativo = c.Boolean(),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.despesa", t => t.id_despesa)
                .Index(t => t.id_despesa);
            
            AddColumn("dbo.usuarios", "Nome", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.despesa_imagem", "id_despesa", "dbo.despesa");
            DropIndex("dbo.despesa_imagem", new[] { "id_despesa" });
            DropColumn("dbo.usuarios", "Nome");
            DropTable("dbo.despesa_imagem");
        }
    }
}
