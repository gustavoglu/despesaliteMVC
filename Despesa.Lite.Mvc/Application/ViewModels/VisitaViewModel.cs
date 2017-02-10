using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class VisitaViewModel
    {
        public VisitaViewModel()
        {
            Id = Guid.NewGuid();
            Despesas = new List<DespesaViewModel>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="")]
        public DateTime Data { get; set; }

        public TimeSpan HoraChegada { get; set; }

        public TimeSpan HoraSaida { get; set; }

        public TimeSpan TempoImprodutivo { get; set; }

        public string Observações { get; set; }

        public ICollection<DespesaViewModel> Despesas { get; set; }

    }
}
