
using Despesa.Lite.Mvc.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class Cliente_UsuariosViewModel
    {
        [Key]
        public Guid Id  { get; set; }

        [Required(ErrorMessage ="")]
        public ApplicationUser Usuario{ get; set; }

        [Required(ErrorMessage = "")]
        public Cliente Cliente { get; set; }
    }
}
