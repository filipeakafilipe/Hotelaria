using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries.Usuario
{
    public class GetTodosUsuariosQuery:IRequest<List<UsuarioVO>>
    {
        public GetTodosUsuariosQuery()
        {

        }
    }
}
