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
    public class GetTodosServicosQueryHandler : IRequestHandler<GetTodosServicosQuery, List<ServicoVO>>
    {
        private readonly IMediator _mediator;
        private readonly IServicosRepository<ServicoVO> _repository;

        public GetTodosServicosQueryHandler(IMediator mediator, IServicosRepository<ServicoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<List<ServicoVO>> Handle(GetTodosServicosQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
