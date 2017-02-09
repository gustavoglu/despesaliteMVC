using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string CriadoPor { get; set; } = "";

        public string DeletadoPor { get; set; } = "";

        public string AtualizadoPor { get; set; } = "";

        public string AtivadoPor { get; set; } = "";

        public string DesativadoPor { get; set; } = "";

        public DateTime CriadoEm { get; set; }

        public DateTime DeletadoEm { get; set; }

        public bool Ativo { get; set; }

        public bool Deletado { get; set; }
    }
}