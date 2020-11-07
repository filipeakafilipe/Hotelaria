using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries.Usuario
{
    public class GetUsuarioByLoginQuery : IRequest<UsuarioVO>
    {
        public GetUsuarioByLoginQuery(string login)
        {
            Login = login;
        }

        public string Login { get; set; }
    }
}
