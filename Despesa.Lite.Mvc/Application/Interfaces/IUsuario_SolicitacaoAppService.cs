using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IUsuario_SolicitacaoAppService : IDisposable
    {
        Usuario_SolicitacaoViewModel Criar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        Usuario_SolicitacaoViewModel Atualizar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        Usuario_SolicitacaoViewModel TrazerPorId(Guid Id);

        Usuario_SolicitacaoViewModel Ativar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        Usuario_SolicitacaoViewModel Desativar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        IEnumerable<Usuario_SolicitacaoViewModel> TrazerTodosAtivos();

        int Remover(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        void Aceitar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

        void Recusar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel);

    }
}