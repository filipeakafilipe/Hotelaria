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
    public class GetComandaUsuarioByIdQueryHandler : IRequestHandler<GetComandaUsuarioByIdQuery, ComandasUsuariosVO>
    {
        private readonly IMediator _mediator;
        private readonly IComandasUsuariosRepository<ComandasUsuariosVO> _repository;

        public GetComandaUsuarioByIdQueryHandler(IMediator mediator, IComandasUsuariosRepository<ComandasUsuariosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<ComandasUsuariosVO> Handle(GetComandaUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
