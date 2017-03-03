using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Despesa.Lite.Mvc.Models.Repository
{
    public class Usuario_SolicitacaoRepository : Repository<Usuario_Solicitacao>, IUsuario_SolicitacaoRepository
    {
        protected ApplicationUser usuarioSolicitante;

        public override Usuario_Solicitacao Criar(Usuario_Solicitacao obj)
        {
            usuarioSolicitante =  db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);

            if (usuarioSolicitante != null)
            {
                obj.id_usuario = usuarioSolicitante.Id;

                return base.Criar(obj);

            }else
            {
                return null;
            }
         
        }

        public Usuario_Solicitacao Aceitar(Usuario_Solicitacao usuario_Solicitacao)
        {
            

            usuario_Solicitacao.Status = 1;

            username = HttpContext.Current.User.Identity.Name;
            usuario = db.Set<ApplicationUser>().SingleOrDefault(u => u.UserName == username);

            usuarioSolicitante = db.Set<ApplicationUser>().SingleOrDefault(u => u.Id == usuario_Solicitacao.id_usuario);
            usuarioSolicitante.id_companhia = usuario_Solicitacao.id_companhia;

            var entryusuarioSolic = db.Entry(usuarioSolicitante);

            var entrySolicitacao = db.Entry(usuario_Solicitacao);

            this.db.Set<Usuario_Solicitacao>().Attach(usuario_Solicitacao);

            this.db.Set<ApplicationUser>().Attach(usuarioSolicitante);

            entryusuarioSolic.State = System.Data.Entity.EntityState.Modified;

            entrySolicitacao.State = EntityState.Modified;

            //var objAtualizado = this.Atualizar(usuario_Solicitacao);

            this.Salvar();

            return usuario_Solicitacao;
        }

        public Usuario_Solicitacao Recusar(Usuario_Solicitacao usuario_Solicitacao)
        {
            usuario_Solicitacao.Status = 2;

            return this.Atualizar(usuario_Solicitacao);

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