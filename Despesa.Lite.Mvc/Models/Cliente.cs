using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class Cliente : EntityBase
    {
        public Cliente()
        {
            Visitas = new List<Visita>();

            Cliente_Usuarios = new List<Cliente_Usuarios>();

        }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public virtual ICollection<Visita> Visitas { get; set; }

        public virtual ICollection<Cliente_Usuarios> Cliente_Usuarios { get; set; }
    }
}