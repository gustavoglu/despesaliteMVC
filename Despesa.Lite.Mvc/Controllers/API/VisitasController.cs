using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;

namespace Despesa.Lite.Mvc.Controllers.API
{
    public class VisitasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IVisitaAppService _VisitaAppService;

        public VisitasController()
        {
            _VisitaAppService = new VisitaAppService();
        }
        // GET: api/VisitaViewModels
        public IQueryable<VisitaViewModel> GetVisitaViewModel()
        {
            return _VisitaAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/VisitaViewModels/5
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult GetVisitaViewModel(Guid id)
        {
            VisitaViewModel visitaViewModel = _VisitaAppService.TrazerPorId(id);
            if (visitaViewModel == null)
            {
                return NotFound();
            }

            return Ok(visitaViewModel);
        }

        // PUT: api/VisitaViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitaViewModel(Guid id, VisitaDespesaClienteViewModel visitaDespesaClienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitaDespesaClienteViewModel.Visita.Id)
            {
                return BadRequest();
            }

            _VisitaAppService.Atualizar(visitaDespesaClienteViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VisitaViewModels
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult PostVisitaViewModel(VisitaDespesaClienteViewModel visitaDespesaClienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _VisitaAppService.Criar(visitaDespesaClienteViewModel);

            return CreatedAtRoute("DefaultApi", new { id = visitaDespesaClienteViewModel.Visita.Id }, visitaDespesaClienteViewModel);
        }

        // DELETE: api/VisitaViewModels/5
        [ResponseType(typeof(VisitaViewModel))]
        public IHttpActionResult DeleteVisitaViewModel(Guid id)
        {
            VisitaViewModel visita = _VisitaAppService.TrazerPorId(id);
            VisitaDespesaClienteViewModel visitaDespesaClienteViewModel = new VisitaDespesaClienteViewModel()
            {
                Visita = visita,
                Cliente = visita.Cliente,
                Despesas = visita.Despesas
                
            };

            if (visitaDespesaClienteViewModel == null)
            {
                return NotFound();
            }

            _VisitaAppService.Remover(visitaDespesaClienteViewModel);

            return Ok(visitaDespesaClienteViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _VisitaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitaViewModelExists(Guid id)
        {
            return db.Visitas.Count(e => e.Id == id) > 0;
        }
    }
}