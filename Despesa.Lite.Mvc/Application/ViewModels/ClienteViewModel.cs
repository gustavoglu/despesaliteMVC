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
        public ClienteViewModel()
        {
            Id = Guid.NewGuid();
            Visitas = new List<VisitaViewModel>();
            Cliente_Usuarios = new List<Cliente_UsuariosViewModel>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="")]
        [MaxLength(100,ErrorMessage = "")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "")]
        public string RazaoSocial { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Deletado { get; set; }

        public virtual ICollection<VisitaViewModel> Visitas { get; set; }

        public virtual ICollection<Cliente_UsuariosViewModel> Cliente_Usuarios { get; set; }
    }
}

