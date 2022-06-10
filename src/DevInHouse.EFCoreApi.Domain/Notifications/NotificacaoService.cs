﻿using DevInHouse.EFCoreApi.Domain.Interfaces;
using FluentValidation.Results;
using System.Net;

namespace DevInHouse.EFCoreApi.Domain.Notifications
{
    public class NotificacaoService : INotificacaoService
    {
        public IList<Notificacao> Notificacoes { get; }

        public NotificacaoService()
        {
            Notificacoes = new List<Notificacao>();
        }

        public void InserirNotificacao(Notificacao notificacao) => Notificacoes.Add(notificacao);

        public void InserirNotificacoes(ValidationResult validationResult)
        {
            foreach (ValidationFailure? error in validationResult.Errors)
            {
                InserirNotificacao(new Notificacao()
                {
                    Mensagem = error.ErrorMessage,
                    StatusCode = HttpStatusCode.UnprocessableEntity
                });
            }
        }

        public bool ExistemNotificacoes() => Notificacoes.Any();

        public IEnumerable<Notificacao> ObterNotificacoes() => Notificacoes;
    }
}
