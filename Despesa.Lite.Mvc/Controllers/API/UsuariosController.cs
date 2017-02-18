using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Despesa.Lite.Mvc.Controllers.API
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuariosController()
        {
            usuarioAppService = new UsuarioAppService();
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> MeusUsuarios()
        {
            return usuarioAppService.TrazerUsuariosDaCompanhia().ToList();            
        }
    }
}
