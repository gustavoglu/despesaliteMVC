
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Models.Interfaces.Repository
{
    public interface IUsuario_SolicitacaoRepository : IRepository<Usuario_Solicitacao>
    {
        Usuario_Solicitacao Aceitar(Usuario_Solicitacao usuario_Solicitacao);

        Usuario_Solicitacao Recusar(Usuario_Solicitacao usuario_Solicitacao);



    }
}