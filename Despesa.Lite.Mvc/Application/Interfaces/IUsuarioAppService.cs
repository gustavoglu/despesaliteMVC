using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        IEnumerable<UsuarioViewModel> TrazerUsuariosDaCompanhia();

        //UsuarioViewModel AdicionarClientesAoUsuario(string IdUsuario, Guid IdCliente);
    }
}