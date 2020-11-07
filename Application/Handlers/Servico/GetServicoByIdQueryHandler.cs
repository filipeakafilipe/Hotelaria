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
    public class GetServicoByIdQueryHandler : IRequestHandler<GetServicoByIdQuery, ServicoVO>
    {
        private readonly IMediator _mediator;
        private readonly IServicosRepository<ServicoVO> _repository;

        public GetServicoByIdQueryHandler(IMediator mediator, IServicosRepository<ServicoVO> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<ServicoVO> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}
