using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class DespesaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="")]
        public VisitaViewModel Visita { get; set; }

        public int Quilometragem { get; set; }

        public double Pedagio { get; set; }

        public double Refeicao { get; set; }

        public double Outros { get; set; }

        public string Detalhes { get; set; }
    }
}
