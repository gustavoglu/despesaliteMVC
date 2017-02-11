using Despesa.Lite.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public class Despesa_ImagemConfig : EntityTypeConfiguration<Depesa_Imagem>
    {
        public Despesa_ImagemConfig()
        {
            ToTable("despesa_imagem");

            HasRequired(di => di.Despesa)
                .WithMany(d => d.Despesa_Imagens)
                .HasForeignKey(di => di.id_despesa);

            Property(di => di.Descricao).IsRequired();

            Property(di => di.imagem_link).IsRequired().HasMaxLength(1000);

        }
    }
}