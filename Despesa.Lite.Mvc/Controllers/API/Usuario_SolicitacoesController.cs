using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;

namespace Despesa.Lite.Mvc.Controllers.API
{
    public class Usuario_SolicitacoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected readonly IUsuario_SolicitacaoAppService _usuario_SolicitacaoAppService;

        public Usuario_SolicitacoesController()
        {
            _usuario_SolicitacaoAppService = new Usuario_SolicitacaoAppService();
        }

        // GET: api/Usuario_SolicitacaoViewModel
        public IQueryable<Usuario_SolicitacaoViewModel> GetUsuario_SolicitacaoViewModel()
        {
            return _usuario_SolicitacaoAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/Usuario_SolicitacaoViewModel/5
        [ResponseType(typeof(Usuario_SolicitacaoViewModel))]
        public IHttpActionResult GetUsuario_SolicitacaoViewModel(Guid id)
        {
            Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel = _usuario_SolicitacaoAppService.TrazerPorId(id);
            if (usuario_SolicitacaoViewModel == null)
            {
                return NotFound();
            }

            return Ok(usuario_SolicitacaoViewModel);
        }

        // PUT: api/Usuario_SolicitacaoViewModel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario_SolicitacaoViewModel(Guid id, Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario_SolicitacaoViewModel.Id)
            {
                return BadRequest();
            }

            _usuario_SolicitacaoAppService.Atualizar(usuario_SolicitacaoViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario_SolicitacaoViewModel
        [ResponseType(typeof(Usuario_SolicitacaoViewModel))]
        public IHttpActionResult PostUsuario_SolicitacaoViewModel(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usuario_SolicitacaoAppService.Criar(usuario_SolicitacaoViewModel);

            return CreatedAtRoute("DefaultApi", new { id = usuario_SolicitacaoViewModel.Id }, usuario_SolicitacaoViewModel);
        }

        // DELETE: api/Usuario_SolicitacaoViewModel/5
        [ResponseType(typeof(Usuario_SolicitacaoViewModel))]
        public IHttpActionResult DeleteUsuario_SolicitacaoViewModel(Guid id)
        {
            Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel = _usuario_SolicitacaoAppService.TrazerPorId(id);
            if (usuario_SolicitacaoViewModel == null)
            {
                return NotFound();
            }

            _usuario_SolicitacaoAppService.Remover(usuario_SolicitacaoViewModel);

            return Ok(usuario_SolicitacaoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuario_SolicitacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Usuario_SolicitacaoViewModelExists(Guid id)
        {
            return db.Usuario_Solicitacoes.Count(e => e.Id == id) > 0;
        }
    }
}