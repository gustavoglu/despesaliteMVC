using Despesa.Lite.Mvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;
using AutoMapper;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly ApplicationDbContext identityDb;
        private string id_companhia;

        public UsuarioAppService()
        {
            identityDb = new ApplicationDbContext();
        }

        public IEnumerable<UsuarioViewModel> TrazerUsuariosDaCompanhia()
        {
            id_companhia = identityDb.Set<ApplicationUser>().SingleOrDefault( u => u.UserName == HttpContext.Current.User.Identity.Name).Id;
            var usuarios = identityDb.Set<ApplicationUser>().Where(u => u.id_companhia == id_companhia).ToList() ;
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);


        }
    }
}