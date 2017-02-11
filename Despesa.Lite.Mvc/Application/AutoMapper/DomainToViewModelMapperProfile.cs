using AutoMapper;
using Despesa.Lite.Mvc.Application.ViewModels;
using Despesa.Lite.Mvc.Models;

namespace Despesa.Lite.Mvc.Application.AutoMapper
{
    public class DomainToViewModelMapperProfile : Profile
    {
        public DomainToViewModelMapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Despesa.Lite.Mvc.Models.Despesa, DespesaViewModel>().ReverseMap();
            CreateMap<Visita, VisitaViewModel>().ReverseMap();
            CreateMap<Cliente_Usuarios, Cliente_UsuariosViewModel>().ReverseMap();
            CreateMap<Usuario_Solicitacao, Usuario_SolicitacaoViewModel>().ReverseMap();
            CreateMap<DespesaViewModel, Despesa_ImagemViewModel>().ReverseMap();

        }
    }
}
