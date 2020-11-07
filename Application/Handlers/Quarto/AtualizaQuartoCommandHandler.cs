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
    public class AtualizaQuartoCommandHandler : IRequestHandler<AtualizaQuartoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IQuartosRepository<QuartoVO> _repository;

        public AtualizaQuartoCommandHandler(IMediator mediator, IQuartosRepository<QuartoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }


        public async Task<string> Handle(AtualizaQuartoCommand request, CancellationToken cancellationToken)
        {
            var quarto = new QuartoVO
            {
                Id = request.Id,
                Nome = request.Nome,
                Preco = request.Preco
            };

            try
            {
                _repository.Atualizar(request.Id, quarto);

                await _mediator.Publish(new QuartoAtualizadoNotification
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Preco = request.Preco
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
                return await Task.FromResult(ResultadoOperacaoMessage.ErroInterno);
            }
        }
    }
}
