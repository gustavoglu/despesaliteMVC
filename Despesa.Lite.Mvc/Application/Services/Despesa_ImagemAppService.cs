using Despesa.Lite.Mvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Despesa.Lite.Mvc.Application.ViewModels;
using AutoMapper;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Models.Repository;
using Despesa.Lite.Mvc.Models;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class Despesa_ImagemAppService : IDespesa_ImagemAppService
    {
        protected readonly IDespesa_ImagemRepository _Despesa_ImagemRepository;

        public Despesa_ImagemAppService()
        {
            _Despesa_ImagemRepository = new Despesa_ImagemRepository();
        }

        public Despesa_ImagemViewModel Ativar(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            var despesa_imagem = Mapper.Map<Depesa_Imagem>(despesa_ImagemViewModel);
            return Mapper.Map<Despesa_ImagemViewModel>(_Despesa_ImagemRepository.Ativar(despesa_imagem));
        }

        public Despesa_ImagemViewModel Atualizar(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            var despesa_imagem = Mapper.Map<Depesa_Imagem>(despesa_ImagemViewModel);
            return Mapper.Map<Despesa_ImagemViewModel>(_Despesa_ImagemRepository.Atualizar(despesa_imagem));
        }

        public Despesa_ImagemViewModel Criar(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            var despesa_imagem = Mapper.Map<Depesa_Imagem>(despesa_ImagemViewModel);
            return Mapper.Map<Despesa_ImagemViewModel>(_Despesa_ImagemRepository.Criar(despesa_imagem));
        }

        public Despesa_ImagemViewModel Desativar(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            var despesa_imagem = Mapper.Map<Depesa_Imagem>(despesa_ImagemViewModel);
            return Mapper.Map<Despesa_ImagemViewModel>(_Despesa_ImagemRepository.Desativar(despesa_imagem));
        }

        public void Dispose()
        {
            _Despesa_ImagemRepository.Dispose();
        }

        public int Remover(Despesa_ImagemViewModel despesa_ImagemViewModel)
        {
            var despesa_imagem = Mapper.Map<Depesa_Imagem>(despesa_ImagemViewModel);
            return _Despesa_ImagemRepository.Remover(despesa_imagem);
        }

        public Despesa_ImagemViewModel TrazerPorId(Guid Id)
        {
            return Mapper.Map<Despesa_ImagemViewModel>(_Despesa_ImagemRepository.TrazerPorId(Id));
        }

        public IEnumerable<Despesa_ImagemViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable <Despesa_ImagemViewModel>>(_Despesa_ImagemRepository.TrazerTodosAtivos());
        }
    }
}