using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Web;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;

namespace Despesa.Lite.Mvc.Models.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase, new()
    {
        ApplicationDbContext db;
        DbSet<T> dbSet;
        DbSet<ApplicationUser> dbusuario;
        ApplicationUser usuario;
        string username;


        public Repository()
        {
            db = new ApplicationDbContext();
            dbSet = db.Set<T>();
            dbusuario = db.Set<ApplicationUser>();
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);
        }

        public virtual T Ativar(T obj)
        {
            obj.Ativo = true;

            var entry = db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            Salvar();

            return obj;

        }

        public virtual T Atualizar(T obj)
        {
            obj.AtualizadoPor = HttpContext.Current.User.Identity.Name;

            var entry = db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            Salvar();

            return obj;

        }

        public virtual T Criar(T obj)
        {
            obj.CriadoEm = DateTime.Now.Date;
            obj.Ativo = true;
            obj.CriadoPor = HttpContext.Current.User.Identity.Name;

            dbSet.Add(obj);

            Salvar();

            return obj;
        }

        public virtual T Desativar(T obj)
        {

            obj.Ativo = false;
            obj.DesativadoPor = HttpContext.Current.User.Identity.Name;

            var entry = db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            Salvar();

            return obj;
        }

        public virtual void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expressao)
        {
            return dbSet.Where(Expressao);
        }

        public virtual int Remover(T obj)
        {
            obj.Deletado = true;
            obj.DeletadoEm = DateTime.Now.Date;
            obj.DeletadoPor = HttpContext.Current.User.Identity.Name;
            obj.Ativo = false;

            var entry = db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            return Salvar();
        }

        public virtual int Salvar()
        {
            return db.SaveChanges();
        }

        public virtual T TrazerPorId(Guid Id)
        {
            if (usuario.Companhia)
            {
                return dbSet.SingleOrDefault(e => e.Id == Id);
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username select obj).SingleOrDefault();
            }
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            if (usuario.Companhia)
            {
                return dbSet;
            }
            else
            {
                return from obj in dbSet where obj.CriadoPor == username select obj;

            }
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Ativo == true);
            }else
            {
                return from obj in dbSet where obj.CriadoPor == username && obj.Ativo == true select obj;
            }
            
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Deletado == true);
            }
            else
            {
                return from obj in dbSet where obj.CriadoPor == username && obj.Deletado == true select obj;
            }
          
        }

        public virtual IEnumerable<T> TrazerTodosInativos()
        {
            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Ativo == false);
            }else
            {
                return from obj in dbSet where obj.CriadoPor == username && obj.Ativo == false select obj;
            }
            
        }
    }
}
