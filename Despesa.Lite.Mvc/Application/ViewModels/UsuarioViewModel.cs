using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        string Id { get; set; }

        public string Nome { get; set; }

        public bool Companhia { get; set; }

        public bool Ativo { get; set; }

        public bool Deletado { get; set; }

        public string id_companhia { get; set; }

        public virtual ICollection<Cliente_UsuariosViewModel> Cliente_Usuarios { get; set; }

        public virtual ICollection<Usuario_SolicitacaoViewModel> Usuario_Solicitacoes { get; set; }

        public virtual ICollection<Usuario_SolicitacaoViewModel> Companhia_Solicitacoes { get; set; }

    }
}