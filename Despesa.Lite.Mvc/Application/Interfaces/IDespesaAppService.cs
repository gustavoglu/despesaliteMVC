using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IDespesaAppService : IDisposable
    {
        DespesaViewModel Criar(DespesaViewModel despesaViewModel);

        DespesaViewModel Atualizar(DespesaViewModel despesaViewModel);

        DespesaViewModel TrazerPorId(Guid Id);

        DespesaViewModel Ativar(DespesaViewModel despesaViewModel);

        DespesaViewModel Desativar(DespesaViewModel despesaViewModel);

        IEnumerable<DespesaViewModel> TrazerTodos();

        IEnumerable<DespesaViewModel> TrazerTodosAtivos();

        IEnumerable<DespesaViewModel> TrazerTodosInativos();

        IEnumerable<DespesaViewModel> TrazerTodosDeletados();

        int Remover(DespesaViewModel despesaViewModel);
    }
}
