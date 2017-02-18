using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;

namespace Despesa.Lite.Mvc.Controllers.API
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _ClienteAppService;

        public ClientesController()
        {
            _ClienteAppService = new ClienteAppService();
        }
        // GET: api/ClienteViewModels
        public IQueryable<ClienteViewModel> GetClienteViewModel()
        {
            return _ClienteAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/ClienteViewModels/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult GetClienteViewModel(Guid id)
        {
            ClienteViewModel clienteViewModel = _ClienteAppService.TrazerPorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return Ok(clienteViewModel);
        }

        // PUT: api/ClienteViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClienteViewModel(Guid id, ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteViewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                _ClienteAppService.Atualizar(clienteViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClienteViewModels
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult PostClienteViewModel(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

      
                _ClienteAppService.Criar(clienteViewModel);



            return CreatedAtRoute("DefaultApi", new { id = clienteViewModel.Id }, clienteViewModel);
        }

        // DELETE: api/ClienteViewModels/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult DeleteClienteViewModel(Guid id)
        {
            ClienteViewModel clienteViewModel = _ClienteAppService.TrazerPorId(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            _ClienteAppService.Remover(clienteViewModel);

            return Ok(clienteViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ClienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteViewModelExists(Guid id)
        {
            if (_ClienteAppService.TrazerPorId(id) != null) { return true; }  else { return false; } ;
        }
    }
}