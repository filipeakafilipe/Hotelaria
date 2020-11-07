using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetServicoByIdQuery : IRequest<ServicoVO>
    {
        public GetServicoByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
