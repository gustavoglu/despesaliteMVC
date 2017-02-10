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
    public class DespesasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IDespesaAppService _DespesaAppService;

        public DespesasController()
        {
            _DespesaAppService = new DespesaAppService();
        }
        // GET: api/DespesaViewModels
        public IQueryable<DespesaViewModel> GetDespesaViewModel()
        {
            return _DespesaAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/DespesaViewModels/5
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult GetDespesaViewModel(Guid id)
        {
            DespesaViewModel despesaViewModel = _DespesaAppService.TrazerPorId(id);
            if (despesaViewModel == null)
            {
                return NotFound();
            }

            return Ok(despesaViewModel);
        }

        // PUT: api/DespesaViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesaViewModel(Guid id, DespesaViewModel despesaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesaViewModel.Id)
            {
                return BadRequest();
            }
            _DespesaAppService.Atualizar(despesaViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DespesaViewModels
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult PostDespesaViewModel(DespesaViewModel despesaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _DespesaAppService.Criar(despesaViewModel);

            return CreatedAtRoute("DefaultApi", new { id = despesaViewModel.Id }, despesaViewModel);
        }

        // DELETE: api/DespesaViewModels/5
        [ResponseType(typeof(DespesaViewModel))]
        public IHttpActionResult DeleteDespesaViewModel(Guid id)
        {
            DespesaViewModel despesaViewModel = _DespesaAppService.TrazerPorId(id);
            if (despesaViewModel == null)
            {
                return NotFound();
            }

            _DespesaAppService.Remover(despesaViewModel);
            return Ok(despesaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _DespesaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DespesaViewModelExists(Guid id)
        {
            return db.Despesas.Count(e => e.Id == id) > 0;
        }
    }
}