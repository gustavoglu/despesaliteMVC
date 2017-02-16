using Despesa.Lite.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class Usuario_SolicitacaoViewModel
    {
        public Usuario_SolicitacaoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="")]
        [MaxLength(100,ErrorMessage ="")]
        public string Descricao { get; set; }

        public DateTime? DataResposta { get; set; }

        public bool? Confirmado { get; set; }

        public int Status { get; set; }

        public string id_usuario { get; set; } = null;

        public string id_companhia { get; set; } = null;

        //
        // [Required(ErrorMessage ="")]
        // public ApplicationUser Usuario { get; set; }
        //
        // [Required(ErrorMessage = "")]
        // public ApplicationUser Companhia { get; set; }

    }
}