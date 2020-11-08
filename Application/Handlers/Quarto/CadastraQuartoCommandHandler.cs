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
    public class CadastraQuartoCommandHandler : IRequestHandler<CadastraQuartoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IQuartosRepository<QuartoVO> _repository;

        public CadastraQuartoCommandHandler(IMediator mediator, IQuartosRepository<QuartoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraQuartoCommand request, CancellationToken cancellationToken)
        {
            var quarto = new QuartoVO
            {
                Id = request.Id,
                Nome = request.Nome,
                Preco = request.Preco
            };

            try
            {
                _repository.Adicionar(quarto);

                await _mediator.Publish(new QuartoCriadoNotification
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Preco = request.Preco
                });

                return await Task.FromResult(ResultadoOperacaoMessage.Sucesso);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(ResultadoOperacaoMessage.RequisicaoInvalida);
            }
        }
    }
}
