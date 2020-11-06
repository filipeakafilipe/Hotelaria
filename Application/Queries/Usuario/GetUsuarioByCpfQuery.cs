using Hotelaria.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Queries.Usuario
{
    public class GetUsuarioByCpfQuery: IRequest<List<UsuarioVO>>
    {
        public GetUsuarioByCpfQuery(string cpf)
        {
            CPF = cpf;
        }

        public string CPF { get; set; }
    }
}
