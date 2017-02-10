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
    public class Cliente_UsuariosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly ICliente_UsuariosAppService _Cliente_UsuariosAppService;

        public Cliente_UsuariosController()
        {
            _Cliente_UsuariosAppService = new Cliente_UsuariosAppService();
        }
        // GET: api/Cliente_UsuariosViewModel
        public IQueryable<Cliente_UsuariosViewModel> GetCliente_UsuariosViewModel()
        {
            return _Cliente_UsuariosAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/Cliente_UsuariosViewModel/5
        [ResponseType(typeof(Cliente_UsuariosViewModel))]
        public IHttpActionResult GetCliente_UsuariosViewModel(Guid id)
        {
            Cliente_UsuariosViewModel cliente_UsuariosViewModel = _Cliente_UsuariosAppService.TrazerPorId(id);
            if (cliente_UsuariosViewModel == null)
            {
                return NotFound();
            }

            return Ok(cliente_UsuariosViewModel);
        }

        // PUT: api/Cliente_UsuariosViewModel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente_UsuariosViewModel(Guid id, Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente_UsuariosViewModel.Id)
            {
                return BadRequest();
            }

            _Cliente_UsuariosAppService.Atualizar(cliente_UsuariosViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cliente_UsuariosViewModel
        [ResponseType(typeof(Cliente_UsuariosViewModel))]
        public IHttpActionResult PostCliente_UsuariosViewModel(Cliente_UsuariosViewModel cliente_UsuariosViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Cliente_UsuariosAppService.Criar(cliente_UsuariosViewModel);

            return CreatedAtRoute("DefaultApi", new { id = cliente_UsuariosViewModel.Id }, cliente_UsuariosViewModel);
        }

        // DELETE: api/Cliente_UsuariosViewModel/5
        [ResponseType(typeof(Cliente_UsuariosViewModel))]
        public IHttpActionResult DeleteCliente_UsuariosViewModel(Guid id)
        {
            Cliente_UsuariosViewModel cliente_UsuariosViewModel = _Cliente_UsuariosAppService.TrazerPorId(id);
            if (cliente_UsuariosViewModel == null)
            {
                return NotFound();
            }

            _Cliente_UsuariosAppService.Remover(cliente_UsuariosViewModel);
            return Ok(cliente_UsuariosViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Cliente_UsuariosAppService.Dispose();

            }
            base.Dispose(disposing);
        }

        private bool Cliente_UsuariosViewModelExists(Guid id)
        {
            return db.Cliente_Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}