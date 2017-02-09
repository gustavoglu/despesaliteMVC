using AutoMapper;


namespace Despesa.Lite.Mvc.Application.AutoMapper
{
   public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            Mapper.Initialize(m => { m.AddProfile(new DomainToViewModelMapperProfile()) ; });
        }
    }
}
