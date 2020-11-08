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
    public class AtualizaComandaServicoCommandHandler : IRequestHandler<AtualizaComandaServicoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _repository;

        public AtualizaComandaServicoCommandHandler(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AtualizaComandaServicoCommand request, CancellationToken cancellationToken)
        {
            var comandaServico = new ComandasServicosVO
            {
                Id = request.Id,
                ComandaId = request.ComandaId,
                ServicoId = request.ServicoId,
                Quantidade = request.Quantidade
            };

            try
            {
                _repository.Atualizar(request.Id, comandaServico);

                await _mediator.Publish(new ComandaServicoAtualizadoNotification
                {
                    Id = request.Id,
                    ComandaId = request.ComandaId,
                    ServicoId = request.ServicoId,
                    Quantidade = request.Quantidade
                });

                return await Task.FromResult(ResultadoOperacaoMessage.Sucesso);
            }
            catch (KeyNotFoundException ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(ResultadoOperacaoMessage.NaoEncontrado);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(ResultadoOperacaoMessage.RequisicaoInvalida);
            }
        }
    }
}
