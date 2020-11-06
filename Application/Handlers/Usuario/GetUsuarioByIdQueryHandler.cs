using Hotelaria.Application.Models;
using Hotelaria.Application.Queries;
using Hotelaria.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotelaria.Application.Handlers
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioVO>
    {
        private readonly IMediator _mediator;
        private readonly IUsuariosRepository<UsuarioVO> _repository;

        public GetUsuarioByIdQueryHandler(IMediator mediator, IUsuariosRepository<UsuarioVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<UsuarioVO> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
