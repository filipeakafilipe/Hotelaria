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
    public class CadastraServicoCommandHandler : IRequestHandler<CadastraServicoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IServicosRepository<ServicoVO> _repository;

        public CadastraServicoCommandHandler(IMediator mediator, IServicosRepository<ServicoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraServicoCommand request, CancellationToken cancellationToken)
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
                _repository.Adicionar(servico);

                await _mediator.Publish(new ServicoCriadoNotification
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Observacoes = request.Observacoes,
                    Preco = request.Preco
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
