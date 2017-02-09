namespace Despesa.Lite.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente_usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        id_usuario = c.String(nullable: false, maxLength: 100, unicode: false),
                        id_cliente = c.Guid(nullable: false),
                        CriadoPor = c.String(maxLength: 100, unicode: false),
                        DeletadoPor = c.String(maxLength: 100, unicode: false),
                        AtualizadoPor = c.String(maxLength: 100, unicode: false),
                        AtivadoPor = c.String(maxLength: 100, unicode: false),
                        DesativadoPor = c.String(maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(nullable: false),
                        DeletadoEm = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cliente", t => t.id_cliente)
                .ForeignKey("dbo.usuarios", t => t.id_usuario)
                .Index(t => t.id_usuario)
                .Index(t => t.id_cliente);
            
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        RazaoSocial = c.String(maxLength: 100, unicode: false),
                        CriadoPor = c.String(maxLength: 100, unicode: false),
                        DeletadoPor = c.String(maxLength: 100, unicode: false),
                        AtualizadoPor = c.String(maxLength: 100, unicode: false),
                        AtivadoPor = c.String(maxLength: 100, unicode: false),
                        DesativadoPor = c.String(maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(nullable: false),
                        DeletadoEm = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.visita",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        id_despesa = c.Guid(nullable: false),
                        id_cliente = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        HoraChegada = c.Time(nullable: false, precision: 7),
                        HoraSaida = c.Time(nullable: false, precision: 7),
                        TempoImprodutivo = c.Time(nullable: false, precision: 7),
                        Observações = c.String(maxLength: 1000, unicode: false),
                        CriadoPor = c.String(maxLength: 100, unicode: false),
                        DeletadoPor = c.String(maxLength: 100, unicode: false),
                        AtualizadoPor = c.String(maxLength: 100, unicode: false),
                        AtivadoPor = c.String(maxLength: 100, unicode: false),
                        DesativadoPor = c.String(maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(nullable: false),
                        DeletadoEm = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cliente", t => t.id_cliente)
                .Index(t => t.id_cliente);
            
            CreateTable(
                "dbo.despesa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        id_visita = c.Guid(nullable: false),
                        Quilometragem = c.Int(nullable: false),
                        Pedagio = c.Double(nullable: false),
                        Refeicao = c.Double(nullable: false),
                        Outros = c.Double(nullable: false),
                        Detalhes = c.String(maxLength: 1000, unicode: false),
                        CriadoPor = c.String(maxLength: 100, unicode: false),
                        DeletadoPor = c.String(maxLength: 100, unicode: false),
                        AtualizadoPor = c.String(maxLength: 100, unicode: false),
                        AtivadoPor = c.String(maxLength: 100, unicode: false),
                        DesativadoPor = c.String(maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(nullable: false),
                        DeletadoEm = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Deletado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.visita", t => t.id_visita)
                .Index(t => t.id_visita);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 100, unicode: false),
                        SecurityStamp = c.String(maxLength: 100, unicode: false),
                        PhoneNumber = c.String(maxLength: 100, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                        Companhia = c.Boolean(),
                        Ativo = c.Boolean(),
                        Deletado = c.Boolean(),
                        id_companhia = c.String(maxLength: 100, unicode: false),
                        id_conta_usuario = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 100, unicode: false),
                        ClaimType = c.String(maxLength: 100, unicode: false),
                        ClaimValue = c.String(maxLength: 100, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 100, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 100, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.usuario_regras",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 100, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 100, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.regras", t => t.RoleId)
                .ForeignKey("dbo.usuarios", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.regras",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario_regras", "IdentityUser_Id", "dbo.usuarios");
            DropForeignKey("dbo.logins", "IdentityUser_Id", "dbo.usuarios");
            DropForeignKey("dbo.claims", "IdentityUser_Id", "dbo.usuarios");
            DropForeignKey("dbo.usuario_regras", "RoleId", "dbo.regras");
            DropForeignKey("dbo.cliente_usuarios", "id_usuario", "dbo.usuarios");
            DropForeignKey("dbo.cliente_usuarios", "id_cliente", "dbo.cliente");
            DropForeignKey("dbo.despesa", "id_visita", "dbo.visita");
            DropForeignKey("dbo.visita", "id_cliente", "dbo.cliente");
            DropIndex("dbo.regras", "RoleNameIndex");
            DropIndex("dbo.usuario_regras", new[] { "IdentityUser_Id" });
            DropIndex("dbo.usuario_regras", new[] { "RoleId" });
            DropIndex("dbo.logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.usuarios", "UserNameIndex");
            DropIndex("dbo.despesa", new[] { "id_visita" });
            DropIndex("dbo.visita", new[] { "id_cliente" });
            DropIndex("dbo.cliente_usuarios", new[] { "id_cliente" });
            DropIndex("dbo.cliente_usuarios", new[] { "id_usuario" });
            DropTable("dbo.regras");
            DropTable("dbo.usuario_regras");
            DropTable("dbo.logins");
            DropTable("dbo.claims");
            DropTable("dbo.usuarios");
            DropTable("dbo.despesa");
            DropTable("dbo.visita");
            DropTable("dbo.cliente");
            DropTable("dbo.cliente_usuarios");
        }
    }
}
