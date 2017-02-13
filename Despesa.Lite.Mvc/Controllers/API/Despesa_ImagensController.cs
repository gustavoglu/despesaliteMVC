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
using System.Threading.Tasks;
using System.Web;

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

        [AllowAnonymous]
        public Dictionary<bool,string> PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            Dictionary<bool, string> retorno = new Dictionary<bool, string>();

            try
            {
                var username = HttpContext.Current.User.Identity.Name;

                var user = db.Users.SingleOrDefault(u => u.UserName == username);

                string filepath = "";

                string filename = string.Format("{0}_{1}",user.UserName, DateTime.Now.Date.ToString());

                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 5; //Size = 5 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };

                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));

                        var extension = ext.ToLower();

                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);

                            retorno.Add(false, message);

                            return retorno;
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Upload de imagens até 5MB");

                            dict.Add("error", message);

                            retorno.Add(false, message);

                            return retorno;

                        }
                        else
                        {

                            filepath = HttpContext.Current.Server.MapPath("~/DespesaImagens/" + filename + extension);

                            postedFile.SaveAs(filepath);

                        }
                    }

                    var message1 = string.Format("Realizado Upload");

                    retorno.Add(true, filepath);

                    return retorno;
                }
                var res = string.Format("Faça upload de uma Imagem");
                dict.Add("error", res);

                retorno.Add(false, res);

                return retorno;
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);

                retorno.Add(false, ex.Message);

                return retorno;
            }
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