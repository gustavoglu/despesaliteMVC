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
    public class Despesa_ImagensController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected readonly IDespesa_ImagemAppService _Despesa_ImagemAppService;

        public Despesa_ImagensController()
        {
            _Despesa_ImagemAppService = new Despesa_ImagemAppService();
        }
        // GET: api/Despesa_ImagemViewModel
        public IQueryable<Despesa_ImagemViewModel> GetDespesa_ImagemViewModel()
        {
            return _Despesa_ImagemAppService.TrazerTodosAtivos().AsQueryable();
        }

        // GET: api/Despesa_ImagemViewModel/5
        [ResponseType(typeof(Despesa_ImagemViewModel))]
        public IHttpActionResult GetDespesa_ImagemViewModel(Guid id)
        {
            Despesa_ImagemViewModel despesa_ImagemViewModel = _Despesa_ImagemAppService.TrazerPorId(id);
            if (despesa_ImagemViewModel == null)
            {
                return NotFound();
            }

            return Ok(despesa_ImagemViewModel);
        }

        // PUT: api/Despesa_ImagemViewModel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesa_ImagemViewModel(Guid id, Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesa_ImagemViewModel.Id)
            {
                return BadRequest();
            }

            _Despesa_ImagemAppService.Atualizar(despesa_ImagemViewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Despesa_ImagemViewModel
        [ResponseType(typeof(Despesa_ImagemViewModel))]
        public IHttpActionResult PostDespesa_ImagemViewModel(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _Despesa_ImagemAppService.Criar(despesa_ImagemViewModel);

            return CreatedAtRoute("DefaultApi", new { id = despesa_ImagemViewModel.Id }, despesa_ImagemViewModel);
        }

        // DELETE: api/Despesa_ImagemViewModel/5
        [ResponseType(typeof(Despesa_ImagemViewModel))]
        public IHttpActionResult DeleteDespesa_ImagemViewModel(Guid id)
        {
            Despesa_ImagemViewModel despesa_ImagemViewModel = _Despesa_ImagemAppService.TrazerPorId(id);
            if (despesa_ImagemViewModel == null)
            {
                return NotFound();
            }

            _Despesa_ImagemAppService.Remover(despesa_ImagemViewModel);

            return Ok(despesa_ImagemViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Despesa_ImagemAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Despesa_ImagemViewModelExists(Guid id)
        {
            return db.Despesa_Imagens.Count(e => e.Id == id) > 0;
        }
    }
}