using Despesa.Lite.Mvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using Despesa.Lite.Mvc.Application.ViewModels;
using AutoMapper;
using Despesa.Lite.Mvc.Models.Interfaces.Repository;
using Despesa.Lite.Mvc.Models.Repository;
using Despesa.Lite.Mvc.Models;

namespace Despesa.Lite.Mvc.Application.Services
{
    public class Usuario_SolicitacaoAppService : IUsuario_SolicitacaoAppService
    {
        private readonly IUsuario_SolicitacaoRepository _Usuario_SolicitacaoRepository;

        public Usuario_SolicitacaoAppService()
        {
            _Usuario_SolicitacaoRepository = new Usuario_SolicitacaoRepository();
        }

        public void Aceitar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            _Usuario_SolicitacaoRepository.Recusar(usuario_solicitacao);
        }

        public Usuario_SolicitacaoViewModel Ativar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            return Mapper.Map<Usuario_SolicitacaoViewModel>(_Usuario_SolicitacaoRepository.Ativar(usuario_solicitacao));
        }

        public Usuario_SolicitacaoViewModel Atualizar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            return Mapper.Map<Usuario_SolicitacaoViewModel>(_Usuario_SolicitacaoRepository.Atualizar(usuario_solicitacao));
        }

        public Usuario_SolicitacaoViewModel Criar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            return Mapper.Map<Usuario_SolicitacaoViewModel>(_Usuario_SolicitacaoRepository.Criar(usuario_solicitacao));
        }

        public Usuario_SolicitacaoViewModel Desativar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            return Mapper.Map<Usuario_SolicitacaoViewModel>(_Usuario_SolicitacaoRepository.Desativar(usuario_solicitacao));
        }

        public void Dispose()
        {
            _Usuario_SolicitacaoRepository.Dispose();
        }

        public void Recusar(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            _Usuario_SolicitacaoRepository.Recusar(usuario_solicitacao);
        }

        public int Remover(Usuario_SolicitacaoViewModel usuario_SolicitacaoViewModel)
        {
            var usuario_solicitacao = Mapper.Map<Usuario_Solicitacao>(usuario_SolicitacaoViewModel);
            return _Usuario_SolicitacaoRepository.Remover(usuario_solicitacao);
        }

        public Usuario_SolicitacaoViewModel TrazerPorId(Guid Id)
        {

            return Mapper.Map<Usuario_SolicitacaoViewModel>(_Usuario_SolicitacaoRepository.TrazerPorId(Id));
        }

        public IEnumerable<Usuario_SolicitacaoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Usuario_SolicitacaoViewModel>>(_Usuario_SolicitacaoRepository.TrazerTodosAtivos());
        }
    }
}