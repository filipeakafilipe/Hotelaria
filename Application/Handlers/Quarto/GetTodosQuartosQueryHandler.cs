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
    public class GetTodosQuartosQueryHandler : IRequestHandler<GetTodosQuartosQuery, List<QuartoVO>>
    {
        private readonly IMediator _mediator;
        private readonly IQuartosRepository<QuartoVO> _repository;

        public GetTodosQuartosQueryHandler(IMediator mediator, IQuartosRepository<QuartoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<List<QuartoVO>> Handle(GetTodosQuartosQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
