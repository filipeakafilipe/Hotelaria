using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetTodasComandasServicosQuery : IRequest<List<ComandasServicosVO>>
    {
        public GetTodasComandasServicosQuery()
        {

        }
    }
}
