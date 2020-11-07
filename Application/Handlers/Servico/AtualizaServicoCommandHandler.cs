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

namespace Hotelaria.Application.Handlers.Servico
{
    public class AtualizaServicoCommandHandler : IRequestHandler<AtualizaServicoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IServicosRepository<ServicoVO> _repository;

        public AtualizaServicoCommandHandler(IMediator mediator, IServicosRepository<ServicoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AtualizaServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = new ServicoVO
            {
                Id = request.Id,
                Nome = request.Nome,
                Observacoes = request.Observacoes,
                Preco = request.Preco
            };

            try
            {
                _repository.Atualizar(request.Id, servico);

                await _mediator.Publish(new ServicoAtualizadoNotification
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Observacoes = request.Observacoes,
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
