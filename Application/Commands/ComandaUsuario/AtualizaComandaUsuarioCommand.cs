using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Commands
{
    public class AtualizaComandaUsuarioCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
