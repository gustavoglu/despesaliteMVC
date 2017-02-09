using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="")]
        [MaxLength(100,ErrorMessage = "")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "")]
        public string RazaoSocial { get; set; }


        public ICollection<VisitaViewModel> Visitas { get; set; }
    }
}

