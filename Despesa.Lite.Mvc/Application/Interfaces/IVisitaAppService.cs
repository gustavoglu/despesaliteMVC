using Despesa.Lite.Mvc.Application.Services;
using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IVisitaAppService : IDisposable 
    {
        VisitaViewModel Criar(VisitaViewModel visitaViewModel);

        IEnumerable<VisitaViewModel> Criar(IEnumerable<VisitaViewModel> lista_visitaViewModel);

        VisitaViewModel Atualizar(VisitaViewModel visitaViewModel);

        VisitaViewModel TrazerPorId(Guid Id);

        VisitaViewModel Ativar(VisitaViewModel visitaViewModel);

        VisitaViewModel Desativar(VisitaViewModel visitaViewModel);

        IEnumerable<VisitaViewModel> TrazerTodos();

        IEnumerable<VisitaViewModel> TrazerTodosAtivos();

        IEnumerable<VisitaViewModel> TrazerTodosInativos();

        IEnumerable<VisitaViewModel> TrazerTodosDeletados();

        int Remover(VisitaViewModel visitaViewModel);
    }
}
