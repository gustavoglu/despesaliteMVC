using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Despesa.Lite.Mvc.Models.Repository
{
    public class Usuario_SolicitacaoRepository : Repository<Usuario_Solicitacao>, IUsuario_Solicitacao
    {
        protected ApplicationUser usuarioSolicitante;

        public void Aceitar(Usuario_Solicitacao usuario_Solicitacao)
        {
            usuario_Solicitacao.Status = 1;

            username = HttpContext.Current.User.Identity.Name;
            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            usuarioSolicitante = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == usuario_Solicitacao.id_usuario);
            usuarioSolicitante.id_companhia = usuario.Id;

            var entrysolic = db.Entry(usuario_Solicitacao);
            var entryusuarioSolic = db.Entry(usuarioSolicitante);

            entrysolic.State = System.Data.Entity.EntityState.Modified;
            entryusuarioSolic.State = System.Data.Entity.EntityState.Modified;
            
            this.Atualizar(usuario_Solicitacao);

            this.Salvar();
        }

        public void Recusar(Usuario_Solicitacao usuario_Solicitacao)
        {
            usuario_Solicitacao.Status = 2;

            this.Atualizar(usuario_Solicitacao);

        }

        public override Usuario_Solicitacao TrazerPorId(Guid Id)
        {
            username = HttpContext.Current.User.Identity.Name;

            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.SingleOrDefault(s => s.Id == Id && s.id_companhia == usuario.Id);
            }else
            {
                return dbSet.SingleOrDefault(s => s.Id == Id && s.CriadoPor == usuario.UserName);
            }

        }

        public override IEnumerable<Usuario_Solicitacao> TrazerTodosAtivos()
        {
            username = HttpContext.Current.User.Identity.Name;

            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(s=> s.Ativo == true && s.id_companhia == usuario.Id).ToList();
            }
            else
            {
                return dbSet.Where(s => s.Ativo == true && s.CriadoPor == usuario.UserName).ToList();
            }
        }

        public override IEnumerable<Usuario_Solicitacao> TrazerTodos()
        {
            username = HttpContext.Current.User.Identity.Name;

            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(s => s.id_companhia == usuario.Id).ToList();
            }
            else
            {
                return dbSet.Where(s => s.CriadoPor == usuario.UserName).ToList();
            }
        }

        public override IEnumerable<Usuario_Solicitacao> TrazerTodosDeletados()
        {
            username = HttpContext.Current.User.Identity.Name;

            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(s => s.Deletado == true && s.id_companhia == usuario.Id).ToList();
            }
            else
            {
                return dbSet.Where(s => s.Deletado == true && s.CriadoPor == usuario.UserName).ToList();
            }
        }

        public override IEnumerable<Usuario_Solicitacao> TrazerTodosInativos()
        {
            username = HttpContext.Current.User.Identity.Name;

            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            if (usuario.Companhia)
            {
                return dbSet.Where(s => s.Ativo == false && s.id_companhia == usuario.Id).ToList();
            }
            else
            {
                return dbSet.Where(s => s.Ativo == false && s.CriadoPor == usuario.UserName).ToList();
            }
        }
    }
}