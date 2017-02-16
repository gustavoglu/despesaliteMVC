
using Despesa.Lite.Mvc.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class Cliente_UsuariosViewModel
    {
        public Cliente_UsuariosViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id  { get; set; }

        public Guid? id_cliente{ get; set; }

        public string id_usuario { get; set; } = null;
        //[Required(ErrorMessage ="")]
        //public virtual ApplicationUser Usuario{ get; set; }
        //
        //[Required(ErrorMessage = "")]
        //public virtual Cliente Cliente { get; set; }
    }
}
