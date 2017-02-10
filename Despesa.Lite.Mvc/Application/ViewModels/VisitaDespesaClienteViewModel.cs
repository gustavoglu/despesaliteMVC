using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class VisitaDespesaClienteViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public VisitaViewModel Visita { get; set; }

        public ICollection<DespesaViewModel> Despesas { get; set; }
    }
}
