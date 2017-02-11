using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IDespesa_ImagemAppService : IDisposable
    {
        Despesa_ImagemViewModel Criar(Despesa_ImagemViewModel despesa_ImagemViewModel);

        Despesa_ImagemViewModel Atualizar(Despesa_ImagemViewModel despesa_ImagemViewModel);

        Despesa_ImagemViewModel TrazerPorId(Guid Id);

        Despesa_ImagemViewModel Ativar(Despesa_ImagemViewModel despesa_ImagemViewModel);

        Despesa_ImagemViewModel Desativar(Despesa_ImagemViewModel despesa_ImagemViewModel);

        IEnumerable<Despesa_ImagemViewModel> TrazerTodosAtivos();

        int Remover(Despesa_ImagemViewModel despesa_ImagemViewModel);
    }
}