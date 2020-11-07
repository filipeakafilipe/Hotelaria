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
    public class GetComandaServicoByIdQueryHandler : IRequestHandler<GetComandaServicoByIdQuery, ComandasServicosVO>
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _repository;

        public GetComandaServicoByIdQueryHandler(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<ComandasServicosVO> Handle(GetComandaServicoByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
