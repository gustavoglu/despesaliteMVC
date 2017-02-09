
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Mvc.Models.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("cliente");

            HasKey(c => c.Id);

            Property(c => c.Nome).IsRequired();

        }
    }
}
