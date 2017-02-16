using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class Visita : EntityBase
    {
        public Visita()
        {
            Despesas = new List<Despesa>(); 
        }
        public Guid? id_cliente { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan HoraChegada { get; set; }

        public TimeSpan HoraSaida { get; set; }

        public TimeSpan TempoImprodutivo { get; set; }

        public string Observações { get; set; }

        public virtual ICollection<Despesa> Despesas { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}