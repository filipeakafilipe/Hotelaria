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
    public class CadastraComandaServicoCommandHandler : IRequestHandler<CadastraComandaServicoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _repository;

        public CadastraComandaServicoCommandHandler(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraComandaServicoCommand request, CancellationToken cancellationToken)
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
                _repository.Adicionar(comandaServico);

                await _mediator.Publish(new ComandaServicoCriadoNotification
                {
                    Id = request.Id,
                    ComandaId = request.ComandaId,
                    ServicoId = request.ServicoId,
                    Quantidade = request.Quantidade
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
