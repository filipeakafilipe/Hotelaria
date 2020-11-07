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
    public class AtualizaUsuarioCommandHandler : IRequestHandler<AtualizaUsuarioCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IUsuariosRepository<UsuarioVO> _repository;

        public AtualizaUsuarioCommandHandler(IMediator mediator, IUsuariosRepository<UsuarioVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AtualizaUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new UsuarioVO
            {
                Id = request.Id,
                Cpf = request.Cpf,
                Email = request.Email,
                Login = request.Login,
                Nome = request.Nome,
                Senha = request.Nome,
                Telefone = request.Nome
            };

            try
            {
                _repository.Atualizar(request.Id, usuario);

                await _mediator.Publish(new UsuarioAtualizadoNotification
                {
                    Id = request.Id,
                    Cpf = request.Cpf,
                    Email = request.Email,
                    Login = request.Login,
                    Nome = request.Nome,
                    Senha = request.Nome,
                    Telefone = request.Nome
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
