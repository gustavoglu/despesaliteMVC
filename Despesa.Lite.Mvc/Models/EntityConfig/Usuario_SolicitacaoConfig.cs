using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public class Usuario_SolicitacaoConfig : EntityTypeConfiguration<Usuario_Solicitacao>
    {
        public Usuario_SolicitacaoConfig()
        {
            ToTable("usuario_solicitacao");

            HasRequired(us => us.Usuario)
            .WithMany(u => u.Usuario_Solicitacoes)
            .HasForeignKey(us => us.id_usuario);

            HasRequired(us => us.Companhia)
            .WithMany(u => u.Companhia_Solicitacoes)
            .HasForeignKey(us => us.id_companhia);


        }
    }
}