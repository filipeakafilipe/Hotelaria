using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetComandaServicoByIdQuery : IRequest<ComandasServicosVO>
    {
        public GetComandaServicoByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
