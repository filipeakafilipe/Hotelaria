using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetComandaUsuarioByIdQuery : IRequest<ComandasUsuariosVO>
    {
        public GetComandaUsuarioByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
