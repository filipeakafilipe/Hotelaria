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
    public class DeletaComandaServicoCommandHandler : IRequestHandler<DeletaComandaServicoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _repository;

        public DeletaComandaServicoCommandHandler(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeletaComandaServicoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Remover(request.Id);

                await _mediator.Publish(new ComandaServicoExcluidoNotification { Id = request.Id });

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
