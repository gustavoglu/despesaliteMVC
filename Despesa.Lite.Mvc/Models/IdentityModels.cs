using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Despesa.Lite.Mvc.Models.EntityConfig;

namespace Despesa.Lite.Mvc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string Nome { get; set; }

        public bool Companhia { get; set; }

        public bool Ativo { get; set; }

        public bool Deletado { get; set; }

        public string id_companhia { get; set; }

        public Guid id_conta_usuario { get; set; }

        public virtual ICollection<Cliente_Usuarios> Cliente_Usuarios { get; set; }

        public virtual ICollection<Usuario_Solicitacao> Usuario_Solicitacoes { get; set; }

        public virtual ICollection<Usuario_Solicitacao> Companhia_Solicitacoes { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Cliente_Usuarios> Cliente_Usuarios { get; set; }
        public DbSet<Usuario_Solicitacao> Usuario_Solicitacoes { get; set; }
        public DbSet<Depesa_Imagem> Despesa_Imagens { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());

            modelBuilder.Entity<IdentityUser>()
            .ToTable("usuarios");

            modelBuilder.Entity<ApplicationUser>()
            .ToTable("usuarios");

            modelBuilder.Entity<IdentityUserRole>()
            .ToTable("usuario_regras");

            modelBuilder.Entity<IdentityUserLogin>()
            .ToTable("logins");

            modelBuilder.Entity<IdentityUserClaim>()
            .ToTable("claims");

            modelBuilder.Entity<IdentityRole>()
            .ToTable("regras");

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new DespesaConfig());
            modelBuilder.Configurations.Add(new VisitaConfig());
            modelBuilder.Configurations.Add(new Cliente_UsuariosConfig());
            modelBuilder.Configurations.Add(new Usuario_SolicitacaoConfig());
            modelBuilder.Configurations.Add(new Despesa_ImagemConfig());
        }

        public System.Data.Entity.DbSet<Despesa.Lite.Mvc.Application.ViewModels.Usuario_SolicitacaoViewModel> Usuario_SolicitacaoViewModel { get; set; }

        public System.Data.Entity.DbSet<Despesa.Lite.Mvc.Application.ViewModels.Despesa_ImagemViewModel> Despesa_ImagemViewModel { get; set; }
    }
}