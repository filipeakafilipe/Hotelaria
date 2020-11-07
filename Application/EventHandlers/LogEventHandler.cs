using Hotelaria.Application.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotelaria.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<UsuarioCriadoNotification>
    {
        public Task Handle(UsuarioCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Cpf} - {notification.Nome} - {notification.Telefone} - {notification.Email} - {notification.Login} - {notification.Senha}'");
            });
        }

        public Task Handle(UsuarioAtualizadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERAÇÃO: '{notification.Id} - {notification.Cpf} - {notification.Nome} - {notification.Telefone} - {notification.Email} - {notification.Login} - {notification.Senha}'");
            });
        }

        public Task Handle(UsuarioExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id}'");
            });
        }
    }
}
