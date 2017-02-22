using System;
using System.Collections.Generic;
using AutoMapper;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Models.Repository;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class Cliente_UsuariosAppService : ICliente_UsuariosAppService
    {
        protected readonly ICliente_UsuariosRepository _cliente_UsuariosRepository;
        private ApplicationDbContext Db;
        private DbSet<Cliente_Usuarios> DbSet;

        public Cliente_UsuariosAppService()
        {
            _cliente_UsuariosRepository = new Cliente_UsuariosRepository();
            Db = new ApplicationDbContext();
            DbSet = Db.Set<Cliente_Usuarios>();
        }

        public Cliente_UsuariosViewModel Ativar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Ativar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public Cliente_UsuariosViewModel Atualizar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Atualizar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
        }

        public IEnumerable<Cliente_UsuariosViewModel> Criar(IEnumerable<Cliente_UsuariosViewModel> lista_cliente_UsuariosViewModel)
        {


            foreach (var cliente_UsuariosViewModel in lista_cliente_UsuariosViewModel.ToList())
            {
                bool exists = DbSet.ToList().Exists(u => u.id_usuario == cliente_UsuariosViewModel.id_usuario && u.id_cliente == cliente_UsuariosViewModel.id_cliente && u.Ativo == true && u.Deletado == false);

                if (exists)
                {

                }
                else
                {
                    _cliente_UsuariosRepository.Criar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel));
                }

            }

            return lista_cliente_UsuariosViewModel;
        }

        public Cliente_UsuariosViewModel Criar(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            bool exists = DbSet.ToList().Exists(u => u.id_usuario == cliente_UsuariosViewModel.id_usuario && u.id_cliente == cliente_UsuariosViewModel.id_cliente && u.Ativo == true && u.Deletado == false);

            if (exists)
            {
                return cliente_UsuariosViewModel;
            }
            else
            {
                return Mapper.Map<Cliente_UsuariosViewModel>(_cliente_UsuariosRepository.Criar(Mapper.Map<Cliente_Usuarios>(cliente_UsuariosViewModel)));
            }
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

        public IEnumerable<Cliente_UsuariosViewModel> TrazerClientesAtivosDoUsuarioPorId(string id)
        {
            var username = HttpContext.Current.User.Identity.Name;
            var lista = DbSet.Where(u => u.CriadoPor == username && u.id_usuario == id && u.Ativo == true).ToList();
            return Mapper.Map<IEnumerable<Cliente_UsuariosViewModel>>(lista);
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
