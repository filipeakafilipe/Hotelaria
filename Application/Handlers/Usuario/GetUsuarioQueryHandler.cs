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
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, UsuarioVO>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<UsuarioVO> _repository;

        public GetUsuarioQueryHandler(IMediator mediator, IRepository<UsuarioVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<UsuarioVO> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
