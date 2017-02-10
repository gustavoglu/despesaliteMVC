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
    public class Cliente_UsuariosAppService : ICliente_UsuariosAppService 
    {
        protected readonly ICliente_UsuariosRepository _cliente_UsuariosRepository;

        public Cliente_UsuariosAppService()
        {
            _cliente_UsuariosRepository = new Cliente_UsuariosRepository();   
        }

        public Cliente_UsuariosViewModel Ativar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Ativar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public Cliente_UsuariosViewModel Atualizar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Atualizar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public Cliente_UsuariosViewModel Criar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Criar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public Cliente_UsuariosViewModel Desativar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Desativar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public void Dispose()
        {
            _cliente_UsuariosRepository.Dispose();
        }

        public int Remover(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return _cliente_UsuariosRepository.Remover(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel));
        }

        public Cliente_UsuariosViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.TrazerPorId(Id));
        }

        public IEnumerable<Cliente_UsuariosViewModel> TrazerTodos()
        {
            return Mapper.Map<IEnumerable<Cliente_UsuariosViewModel>>(_cliente_UsuariosRepository.TrazerTodos());
        }

        public IEnumerable<Cliente_UsuariosViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Cliente_UsuariosViewModel>>(_cliente_UsuariosRepository.TrazerTodosAtivos());
        }

        public IEnumerable<Cliente_UsuariosViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Cliente_UsuariosViewModel>>(_cliente_UsuariosRepository.TrazerTodosDeletados());
        }

        public IEnumerable<Cliente_UsuariosViewModel> TrazerTodosInativos()
        {
            return Mapper.Map<IEnumerable<Cliente_UsuariosViewModel>>(_cliente_UsuariosRepository.TrazerTodosInativos());
        }
    }
}
