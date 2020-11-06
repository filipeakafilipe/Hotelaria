using Hotelaria.Application.Commands;
using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hotelaria.Application.Notifications;

namespace Hotelaria.Application.Handlers
{
    public class CadastraUsuarioCommandHandler : IRequestHandler<CadastraUsuarioCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IUsuariosRepository<UsuarioVO> _repository;

        public CadastraUsuarioCommandHandler(IMediator mediator, IUsuariosRepository<UsuarioVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CadastraUsuarioCommand request, CancellationToken cancellationToken)
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
                _repository.Adicionar(usuario);

                await _mediator.Publish(new UsuarioCriadoNotification
                {
                    Id = request.Id,
                    Cpf = request.Cpf,
                    Email = request.Email,
                    Login = request.Login,
                    Nome = request.Nome,
                    Senha = request.Nome,
                    Telefone = request.Nome
                });

                return await Task.FromResult("Usuário criado com sucesso.");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
