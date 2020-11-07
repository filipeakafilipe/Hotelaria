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

        public Task Handle(ServicoCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Observacoes} - {notification.Preco}'");
            });
        }

        public Task Handle(ServicoAtualizadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERAÇÃO: '{notification.Id} - {notification.Nome} - {notification.Observacoes} - {notification.Preco}'");
            });
        }

        public Task Handle(ServicoExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id}'");
            });
        }

        public Task Handle(QuartoCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Preco}'");
            });
        }

        public Task Handle(QuartoAtualizadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERAÇÃO: '{notification.Id} - {notification.Nome} - {notification.Preco}'");
            });
        }

        public Task Handle(QuartoExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id}'");
            });
        }

        public Task Handle(ComandaCriadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Dias} - {notification.Ativa} - {notification.DataAbertura} - {notification.DataEncerramento} - {notification.Total}'");
            });
        }

        public Task Handle(ComandaAtualizadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Dias} - {notification.Ativa} - {notification.DataAbertura} - {notification.DataEncerramento} - {notification.Total}'");
            });
        }

        public Task Handle(ComandaExcluidaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id}'");
            });
        }

        public Task Handle(ComandaServicoCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Quantidade} - {notification.ComandaId} - {notification.ServicoId}'");
            });
        }

        public Task Handle(ComandaServicoAtualizadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Quantidade} - {notification.ComandaId} - {notification.ServicoId}'");
            });
        }

        public Task Handle(ComandaServicoExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id}'");
            });
        }

        public Task Handle(ComandaUsuarioCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} -  {notification.ComandaId} - {notification.UsuarioId}'");
            });
        }

        public Task Handle(ComandaUsuarioAtualizadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} -  {notification.ComandaId} - {notification.UsuarioId}'");
            });
        }

        public Task Handle(ComandaUsuarioExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id}'");
            });
        }
    }
}
