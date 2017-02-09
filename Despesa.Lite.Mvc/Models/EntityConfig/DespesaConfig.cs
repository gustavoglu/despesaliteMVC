using System.Data.Entity.ModelConfiguration;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public class DespesaConfig : EntityTypeConfiguration<Despesa>
    {
        public DespesaConfig()
        {
            ToTable("despesa");

            HasRequired(d => d.Visita)
                .WithMany(v => v.Despesas)
                .HasForeignKey(d => d.id_visita);

            Property(d => d.Refeicao).HasColumnType("float");
            Property(d => d.Pedagio).HasColumnType("float");
            Property(d => d.Detalhes).HasMaxLength(1000);

        }
    }
}
