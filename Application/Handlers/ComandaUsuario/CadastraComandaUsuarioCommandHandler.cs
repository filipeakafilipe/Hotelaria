using Hotelaria.Application.Commands;
using Hotelaria.Application.Messages;
using Hotelaria.Application.Models;
using Hotelaria.Application.Notifications;
using Hotelaria.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotelaria.Application.Handlers
{
    public class CadastraComandaUsuarioCommandHandler : IRequestHandler<CadastraComandaUsuarioCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IComandasUsuariosRepository<ComandasUsuariosVO> _repository;

        public CadastraComandaUsuarioCommandHandler(IMediator mediator, IComandasUsuariosRepository<ComandasUsuariosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraComandaUsuarioCommand request, CancellationToken cancellationToken)
        {
            var comandaUsuario = new ComandasUsuariosVO
            {
                Id = request.Id,
                ComandaId = request.ComandaId,
                UsuarioId = request.UsuarioId
            };

            try
            {
                _repository.Adicionar(comandaUsuario);

                await _mediator.Publish(new ComandaUsuarioCriadoNotification
                {
                    Id = request.Id,
                    ComandaId = request.ComandaId,
                    UsuarioId = request.UsuarioId
                });

                return await Task.FromResult(ResultadoOperacaoMessage.Sucesso);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(result: ResultadoOperacaoMessage.RequisicaoInvalida);
            }
        }
    }
}
