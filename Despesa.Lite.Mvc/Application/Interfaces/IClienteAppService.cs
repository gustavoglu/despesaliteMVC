
using System;
using System.Collections.Generic;
using Despesa.Lite.Mvc.Application.ViewModels;

namespace Despesa.Lite.Mvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Criar(ClienteViewModel clienteViewModel);

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        ClienteViewModel TrazerPorId(Guid Id);

        ClienteViewModel Ativar(ClienteViewModel clienteViewModel);

        ClienteViewModel Desativar(ClienteViewModel clienteViewModel);

        IEnumerable<ClienteViewModel> TrazerTodos();

        IEnumerable<ClienteViewModel> TrazerTodosAtivos();

        IEnumerable<ClienteViewModel> TrazerTodosInativos();

        IEnumerable<ClienteViewModel> TrazerTodosDeletados();

        int Remover(ClienteViewModel clienteViewModel);

        //ClienteViewModel AdicionarClientesAoUsuario(ClienteViewModel clienteViewModel);

    }
}
