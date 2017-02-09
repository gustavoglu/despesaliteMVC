using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IVisitaAppService : IDisposable 
    {
        VisitaDespesaClienteViewModel Criar(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel);

        VisitaDespesaClienteViewModel Atualizar(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel);

        VisitaViewModel TrazerPorId(Guid Id);

        VisitaDespesaClienteViewModel Ativar(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel);

        VisitaDespesaClienteViewModel Desativar(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel);

        IEnumerable<VisitaViewModel> TrazerTodos();

        IEnumerable<VisitaViewModel> TrazerTodosAtivos();

        IEnumerable<VisitaViewModel> TrazerTodosInativos();

        IEnumerable<VisitaViewModel> TrazerTodosDeletados();

        int Remover(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel);
    }
}
