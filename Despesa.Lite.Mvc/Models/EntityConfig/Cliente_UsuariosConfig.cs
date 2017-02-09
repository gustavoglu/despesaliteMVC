using System.Data.Entity.ModelConfiguration;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public  class Cliente_UsuariosConfig : EntityTypeConfiguration<Cliente_Usuarios>
    {
        public Cliente_UsuariosConfig()
        {
            ToTable("cliente_usuarios");

            HasRequired(cs => cs.Usuario)
                .WithMany(u => u.Cliente_Usuarios)
                .HasForeignKey(cs => cs.id_usuario);

            HasRequired(cs => cs.Cliente)
                .WithMany(c => c.Cliente_Usuarios)
                .HasForeignKey(cs => cs.id_cliente);


        }
    }
}
