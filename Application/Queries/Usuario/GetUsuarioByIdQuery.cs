using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioVO>
    {
        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
