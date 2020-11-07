using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Commands
{
    public class CadastraComandaServicoCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ComandaId { get; set; }
        public int ServicoId { get; set; }
    }
}
