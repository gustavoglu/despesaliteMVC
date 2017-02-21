
using Despesa.Lite.Mvc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
   public interface ICliente_UsuariosAppService : IDisposable
    {
        Cliente_UsuariosViewModel Criar(Cliente_UsuariosViewModel cliente_UsuariosViewModel);

        IEnumerable <Cliente_UsuariosViewModel> Criar(IEnumerable<Cliente_UsuariosViewModel> lista_cliente_UsuariosViewModel);

        Cliente_UsuariosViewModel Atualizar(Cliente_UsuariosViewModel cliente_UsuariosViewModel);

        Cliente_UsuariosViewModel TrazerPorId(Guid Id);

        Cliente_UsuariosViewModel Ativar(Cliente_UsuariosViewModel cliente_UsuariosViewModel);

        Cliente_UsuariosViewModel Desativar(Cliente_UsuariosViewModel cliente_UsuariosViewModel);

        IEnumerable<Cliente_UsuariosViewModel> TrazerTodos();

        IEnumerable<Cliente_UsuariosViewModel> TrazerTodosAtivos();

        IEnumerable<Cliente_UsuariosViewModel> TrazerTodosInativos();

        IEnumerable<Cliente_UsuariosViewModel> TrazerTodosDeletados();

        int Remover(Cliente_UsuariosViewModel cliente_UsuariosViewModel);
    }
}
