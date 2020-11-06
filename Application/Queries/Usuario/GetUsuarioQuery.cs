using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetUsuarioQuery : IRequest<UsuarioVO>
    {
        public GetUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
