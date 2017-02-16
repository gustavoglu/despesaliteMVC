using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class Depesa_Imagem : EntityBase
    {
        public Guid? id_despesa { get; set; }

        public string Descricao { get; set; } = "";

        public string imagem_link { get; set; } = "";

        public virtual Despesa Despesa { get; set; }
    }
}