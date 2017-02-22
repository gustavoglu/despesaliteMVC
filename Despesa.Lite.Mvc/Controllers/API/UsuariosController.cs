using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;
using Despesa.Lite.Mvc.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Despesa.Lite.Mvc.Controllers.API
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController()
        {
            _usuarioAppService = new UsuarioAppService();
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> MeusUsuarios()
        {
            return _usuarioAppService.TrazerUsuariosDaCompanhia().ToList();
        }

        [HttpGet]
        [Route("api/Usuarios/Companhias")]
        public IEnumerable<UsuarioViewModel> Companhias()
        {
            return _usuarioAppService.TrazerUsuariosDaCompanhia().ToList();
        }
    }
}
