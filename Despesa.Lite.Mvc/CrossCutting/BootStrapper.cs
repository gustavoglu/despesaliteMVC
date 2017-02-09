
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Models.Repository;
using SimpleInjector;
using System.Web.Http;

namespace Despesa.Lite.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDespesaRepository, DespesaRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ICliente_UsuariosRepository, Cliente_UsuariosRepository>(Lifestyle.Scoped);
            container.Register<IVisitaRepository, VisitaRepository>(Lifestyle.Scoped);
            //container.Register<HttpConfiguration>();
        }
    }
}
