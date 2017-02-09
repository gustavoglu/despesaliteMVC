using System;
using System.Collections.Generic;
using AutoMapper;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Models.Repository;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class DespesaAppService : IDespesaAppService
    {
        protected readonly IDespesaRepository _despesarepository;

        public DespesaAppService()
        {
            _despesarepository = new DespesaRepository();
        }
        public DespesaViewModel Ativar(DespesaViewModel despesaViewModel)
        {
            return Mapper.Map<DespesaViewModel>(_despesarepository.Ativar(Mapper.Map<Despesa.Lite.Mvc.Models.Despesa>(despesaViewModel)));
        }

        public DespesaViewModel Atualizar(DespesaViewModel despesaViewModel)
        {
            return Mapper.Map<DespesaViewModel>(_despesarepository.Atualizar(Mapper.Map<Despesa.Lite.Mvc.Models.Despesa>(despesaViewModel)));
        }

        public DespesaViewModel Criar(DespesaViewModel despesaViewModel)
        {
            return Mapper.Map<DespesaViewModel>(_despesarepository.Criar(Mapper.Map<Despesa.Lite.Mvc.Models.Despesa>(despesaViewModel)));
        }

        public DespesaViewModel Desativar(DespesaViewModel despesaViewModel)
        {
            return Mapper.Map<DespesaViewModel>(_despesarepository.Desativar(Mapper.Map<Despesa.Lite.Mvc.Models.Despesa>(despesaViewModel)));
        }

        public void Dispose()
        {
            _despesarepository.Dispose();
        }

        public int Remover(DespesaViewModel despesaViewModel)
        {
            return _despesarepository.Remover(Mapper.Map<Despesa.Lite.Mvc.Models.Despesa>(despesaViewModel));
        }

        public DespesaViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<DespesaViewModel>(_despesarepository.TrazerPorId(Id));
        }

        public IEnumerable<DespesaViewModel> TrazerTodos()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesarepository.TrazerTodos());
        }

        public IEnumerable<DespesaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesarepository.TrazerTodosAtivos());
        }

        public IEnumerable<DespesaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesarepository.TrazerTodosDeletados());
        }

        public IEnumerable<DespesaViewModel> TrazerTodosInativos()
        {
            return Mapper.Map<IEnumerable<DespesaViewModel>>(_despesarepository.TrazerTodosInativos());
        }
    }
}
