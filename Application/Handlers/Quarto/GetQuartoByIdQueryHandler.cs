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
    public class GetQuartoByIdQueryHandler : IRequestHandler<GetQuartoByIdQuery, QuartoVO>
    {
        private readonly IMediator _mediator;
        private readonly IQuartosRepository<QuartoVO> _repository;

        public GetQuartoByIdQueryHandler(IMediator mediator, IQuartosRepository<QuartoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<QuartoVO> Handle(GetQuartoByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
