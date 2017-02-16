using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class VisitaClienteDespesasViewModel
    {
        public VisitaViewModel Visita { get; set; }

        public ICollection<DespesaViewModel> Despesas { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}