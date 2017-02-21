using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Models.Repository;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using Newtonsoft.Json;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class VisitaAppService : IVisitaAppService
    {
        protected readonly IVisitaRepository _visitarepository;
        protected readonly IDespesaRepository _despesarepository;
        protected readonly IClienteRepository _clientepository;

        public VisitaAppService()
        {
            _visitarepository = new VisitaRepository();
            _despesarepository = new DespesaRepository();
            _clientepository = new ClienteRepository();

        }

        public VisitaViewModel Ativar(VisitaViewModel visitaViewModel)
        {
            var visita = Mapper.Map<Visita>(visitaViewModel);
            var despesa = Mapper.Map<IEnumerable<Despesa.Lite.Mvc.Models.Despesa>>(visitaViewModel.Despesas);

            _visitarepository.Ativar(visita);

            foreach (var item in despesa)
            {
                _despesarepository.Ativar(item);
            }

            return visitaViewModel;
        }

        public VisitaViewModel Atualizar(VisitaViewModel visitaViewModel)
        {
            var visita = Mapper.Map<Visita>(visitaViewModel);

            _visitarepository.Atualizar(visita);

            return visitaViewModel;
        }

        public VisitaViewModel Criar(VisitaViewModel visitaViewModel)
        {
            var visita = Mapper.Map<Visita>(visitaViewModel);
            var cliente = _clientepository.TrazerPorId(visitaViewModel.Id_cliente);

            var visitacriada = _visitarepository.Criar(visita);

            return visitaViewModel;
        }

        public VisitaViewModel Desativar(VisitaViewModel visitaViewModel)
        {
            var visita = Mapper.Map<Visita>(visitaViewModel);
            var despesa = Mapper.Map<IEnumerable<Despesa.Lite.Mvc.Models.Despesa>>(visitaViewModel.Despesas);

            _visitarepository.Desativar(visita);
            foreach (var item in despesa)
            {
                _despesarepository.Desativar(item);
            }

            return visitaViewModel;
        }

        public void Dispose()
        {
            _visitarepository.Dispose();
            _despesarepository.Dispose();
        }

        public int Remover(VisitaViewModel visitaViewModel)
        {
            var visita = Mapper.Map<Visita>(visitaViewModel);
            var despesa = Mapper.Map<IEnumerable<Despesa.Lite.Mvc.Models.Despesa>>(visitaViewModel.Despesas);

            foreach (var item in despesa)
            {
                _despesarepository.Remover(item);
            }

            return _visitarepository.Remover(visita);
        }

        public VisitaViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<VisitaViewModel>(_visitarepository.TrazerPorId(Id));
        }

        public IEnumerable<VisitaViewModel> TrazerTodos()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitarepository.TrazerTodos());
        }

        public IEnumerable<VisitaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitarepository.TrazerTodosAtivos());
        }

        public IEnumerable<VisitaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitarepository.TrazerTodosDeletados());
        }

        public IEnumerable<VisitaViewModel> TrazerTodosInativos()
        {
            return Mapper.Map<IEnumerable<VisitaViewModel>>(_visitarepository.TrazerTodosInativos());
        }

        public IEnumerable<VisitaViewModel> Criar(IEnumerable<VisitaViewModel> lista_visitaViewModel)
        {
            foreach (var visita in lista_visitaViewModel.ToList())
            {
                _visitarepository.Criar(Mapper.Map<Visita>(visita));
            }

            return lista_visitaViewModel.ToList();
        }
    }
}
