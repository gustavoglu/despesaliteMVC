using Despesa.Lite.Mvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using AutoMapper;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Models.Repository;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly ApplicationDbContext identityDb;
        private readonly IClienteRepository clienteRepository;
        private string id_companhia;

        public UsuarioAppService()
        {
            identityDb = new ApplicationDbContext();
            clienteRepository = new ClienteRepository();
        }


        //public Cliente_Usuarios AdicionarClientesAoUsuario(string IdUsuario, Guid IdCliente)
        //{
        //    //var usuario = identityDb.Set<ApplicationUser>().SingleOrDefault(u => u.Id == IdUsuario);
        //    var cliente = identityDb.Set<Cliente>().SingleOrDefault(u => u.Id == IdCliente);

        //    Cliente_Usuarios clienteusuarios = new Cliente_Usuarios()
        //    {
        //        id_usuario = IdUsuario,
        //        id_cliente = IdCliente
        //    };

        //    cliente.Cliente_Usuarios.Add(clienteusuarios);

        //    clienteRepository.Atualizar(cliente);

        //    return clienteusuarios;

        //}

        public void Dispose()
        {
            this.identityDb.Dispose();
        }

        public IEnumerable<UsuarioViewModel> TrazerUsuariosDaCompanhia()
        {
            id_companhia = identityDb.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name).Id;
            var usuarios = identityDb.Set<ApplicationUser>().Where(u => u.id_companhia == id_companhia).ToList();
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
        }

        public IEnumerable<UsuarioViewModel> TrazerCompanhias()
        {
            var companhias = Mapper.Map<IEnumerable<UsuarioViewModel>>(identityDb.Set<ApplicationUser>().Where(u => u.Companhia == true).ToList());//&& u.Ativo == true));
            return companhias;
        }
    }
}