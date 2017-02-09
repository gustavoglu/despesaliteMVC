using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class Despesa : EntityBase
    {
        public Guid id_visita { get; set; }

        public int Quilometragem { get; set; }

        public double Pedagio { get; set; }

        public double Refeicao { get; set; }

        public double Outros { get; set; }

        public string Detalhes { get; set; }

        public virtual Visita Visita { get; set; }
    }
}