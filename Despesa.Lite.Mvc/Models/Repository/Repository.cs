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
        protected ApplicationDbContext db;
        protected DbSet<T> dbSet;
        protected DbSet<ApplicationUser> dbusuario;
        protected ApplicationUser usuario;
        protected string username;


        protected Repository()
        {
            db = new ApplicationDbContext();
            dbSet = db.Set<T>();
            dbusuario = db.Set<ApplicationUser>();
   
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

            var objs = dbSet.Add(obj);

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
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);
            if (usuario.Companhia)
            {
                return dbSet.Where(Expressao).ToList();

            }else
            {
                return dbSet.Where(Expressao).Where(t => t.CriadoPor == username).ToList();
            }
            
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
            username = HttpContext.Current.User.Identity.Name;

            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.SingleOrDefault(e => e.Id == Id);
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username && obj.Id == Id select obj).SingleOrDefault();
            }
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.ToList();
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username select obj).ToList();

            }
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);
            
            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Ativo == true).ToList();
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username && obj.Ativo == true select obj).ToList();
            }

        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Deletado == true).ToList();
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username && obj.Deletado == true select obj).ToList();
            }

        }

        public virtual IEnumerable<T> TrazerTodosInativos()
        {
            username = HttpContext.Current.User.Identity.Name;
            usuario = dbusuario.SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(e => e.Ativo == false).ToList();
            }
            else
            {
                return (from obj in dbSet where obj.CriadoPor == username && obj.Ativo == false select obj).ToList();
            }

        }
    }
}
