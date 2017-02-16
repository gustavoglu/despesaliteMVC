using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.ViewModels
{
    public class Despesa_ImagemViewModel
    {
        public Despesa_ImagemViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id{ get; set; }

        [Required(ErrorMessage ="")]
        [MaxLength(100, ErrorMessage = "")]
        public string Descricao { get; set; } = "";

        [Required(ErrorMessage = "")]
        [MaxLength(1000,ErrorMessage = "")]
        public string imagem_link { get; set; } = "";

        public Guid? id_despesa { get; set; }

        // [Required(ErrorMessage = "")]
        // public virtual DespesaViewModel Despesa { get; set; }
    }
}