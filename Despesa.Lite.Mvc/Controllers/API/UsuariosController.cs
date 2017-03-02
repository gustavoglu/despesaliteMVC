using Despesa.Lite.Mvc.Application.Interfaces;
using Despesa.Lite.Mvc.Application.Services;
using Despesa.Lite.Mvc.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Despesa.Lite.Mvc.Controllers.API
{
    
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController()
        {
            _usuarioAppService = new UsuarioAppService();
        }


        [HttpGet]
        [Route("api/Usuarios/MeusUsuarios")]
        public IEnumerable<UsuarioViewModel> MeusUsuarios()
        {
            return _usuarioAppService.TrazerUsuariosDaCompanhia().ToList();
        }

        [HttpGet]
        [Route("api/Usuarios/Companhias")]
        public IEnumerable<UsuarioViewModel> Companhias()
        {
            return _usuarioAppService.TrazerCompanhias().ToList();
        }
    }
}
