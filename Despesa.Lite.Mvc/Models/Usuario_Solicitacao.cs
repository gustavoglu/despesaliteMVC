﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models
{
    public class Usuario_Solicitacao : EntityBase
    {
        public string Descricao { get; set; } = "";

        public string id_usuario { get; set; } = "";

        public string id_companhia { get; set; } = "";

        public DateTime? DataResposta{ get; set; }

        public bool Confirmado { get; set; }

        public int Status { get; set; }

        public virtual ApplicationUser Usuario { get; set; }

        public virtual ApplicationUser Companhia { get; set; }




    }
}