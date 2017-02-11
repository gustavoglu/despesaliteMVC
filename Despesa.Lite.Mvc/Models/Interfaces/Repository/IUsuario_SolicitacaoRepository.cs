
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models.Interfaces.Repository
{
    public interface IUsuario_SolicitacaoRepository : IRepository<Usuario_Solicitacao>
    {

        void Aceitar(Usuario_Solicitacao usuario_Solicitacao);

        void Recusar(Usuario_Solicitacao usuario_Solicitacao);
    }
}