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
    public class GetTodasComandasServicosQueryHandler : IRequestHandler<GetTodasComandasServicosQuery, List<ComandasServicosVO>>
    {
        private readonly IMediator _mediator;
        private readonly IComandasServicosRepository<ComandasServicosVO> _repository;

        public GetTodasComandasServicosQueryHandler(IMediator mediator, IComandasServicosRepository<ComandasServicosVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<List<ComandasServicosVO>> Handle(GetTodasComandasServicosQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
