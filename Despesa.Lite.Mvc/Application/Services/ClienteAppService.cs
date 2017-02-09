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
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienterepository;

        public ClienteAppService()
        {
            _clienterepository = new ClienteRepository();
        }

        public ClienteViewModel Ativar(ClienteViewModel clienteViewModel)
        {
           return Mapper.Map<ClienteViewModel>(_clienterepository.Ativar(Mapper.Map<Cliente>(clienteViewModel)));
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            return Mapper.Map<ClienteViewModel>(_clienterepository.Atualizar(Mapper.Map<Cliente>(clienteViewModel)));
        }

        public ClienteViewModel Criar(ClienteViewModel clienteViewModel)
        {
            return Mapper.Map<ClienteViewModel>(_clienterepository.Criar(Mapper.Map<Cliente>(clienteViewModel)));
        }

        public ClienteViewModel Desativar(ClienteViewModel clienteViewModel)
        {
            return Mapper.Map<ClienteViewModel>(_clienterepository.Desativar(Mapper.Map<Cliente>(clienteViewModel)));
        }

        public void Dispose()
        {
            _clienterepository.Dispose();
        }

        public int Remover(ClienteViewModel clienteViewModel)
        {
            return _clienterepository.Remover(Mapper.Map<Cliente>(clienteViewModel));
        }

        public ClienteViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<ClienteViewModel>(_clienterepository.TrazerPorId(Id));
        }

        public IEnumerable<ClienteViewModel> TrazerTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienterepository.TrazerTodos());
        }

        public IEnumerable<ClienteViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienterepository.TrazerTodosAtivos());
        }

        public IEnumerable<ClienteViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienterepository.TrazerTodosDeletados());
        }

        public IEnumerable<ClienteViewModel> TrazerTodosInativos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienterepository.TrazerTodosInativos());
        }
    }
}
