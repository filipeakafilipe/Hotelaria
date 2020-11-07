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
    public class GetTodasComandasQueryHandler : IRequestHandler<GetTodasComandasQuery, List<ComandaVO>>
    {
        private readonly IMediator _mediator;
        private readonly IComandasRepository<ComandaVO> _repository;

        public GetTodasComandasQueryHandler(IMediator mediator, IComandasRepository<ComandaVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<List<ComandaVO>> Handle(GetTodasComandasQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
