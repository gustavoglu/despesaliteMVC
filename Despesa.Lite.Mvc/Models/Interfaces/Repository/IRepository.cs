using Despesa.Lite.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Despesa.Lite.Mvc.Models.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        T Criar(T obj);

        T Atualizar(T obj);

        T TrazerPorId(Guid Id);

        T Ativar(T obj);

        T Desativar(T obj);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerTodosAtivos();

        IEnumerable<T> TrazerTodosInativos();

        IEnumerable<T> TrazerTodosDeletados();

        IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expressao);

        int Remover(T obj);

        int Salvar();


    }
}
