using Hotelaria.Application.Models;
using Hotelaria.Application.Queries.Usuario;
using Hotelaria.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotelaria.Application.Handlers.Usuario
{
    public class GetUsuarioByCpfQueryHandler : IRequestHandler<GetUsuarioByCpfQuery, List<UsuarioVO>>
    {
        private readonly IMediator _mediator;
        private readonly IUsuariosRepository<UsuarioVO> _repository;

        public GetUsuarioByCpfQueryHandler(IMediator mediator, IUsuariosRepository<UsuarioVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<List<UsuarioVO>> Handle(GetUsuarioByCpfQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.CPF);
        }
    }
}
