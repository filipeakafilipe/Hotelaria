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
    public class CadastraComandaCommandHandler : IRequestHandler<CadastraComandaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IComandasRepository<ComandaVO> _repository;

        public CadastraComandaCommandHandler(IMediator mediator, IComandasRepository<ComandaVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraComandaCommand request, CancellationToken cancellationToken)
        {
            var comanda = new ComandaVO
            {
                Id = request.Id,
                Ativa = request.Ativa,
                DataAbertura = request.DataAbertura,
                DataEncerramento = request.DataEncerramento,
                Dias = request.Dias,
                Total = request.Total
            };

            try
            {
                _repository.Adicionar(comanda);

                await _mediator.Publish(new ComandaCriadaNotification
                {
                    Id = request.Id,
                    Ativa = request.Ativa,
                    DataAbertura = request.DataAbertura,
                    DataEncerramento = request.DataEncerramento,
                    Dias = request.Dias,
                    Total = request.Total
                });

                return await Task.FromResult(ResultadoOperacaoMessage.Sucesso);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(ResultadoOperacaoMessage.ErroInterno);
            }
        }
    }
}
