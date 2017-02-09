using System.Data.Entity.ModelConfiguration;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public  class VisitaConfig : EntityTypeConfiguration<Visita>
    {
        public VisitaConfig()
        {
            ToTable("visita");

            HasRequired(v => v.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.id_cliente);

            Property(v => v.Data).IsRequired();

            Property(v => v.Observações).IsOptional().HasMaxLength(1000);


        }
    }
}
