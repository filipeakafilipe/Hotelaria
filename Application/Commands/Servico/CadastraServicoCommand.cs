using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Commands
{
    public class CadastraServicoCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacoes { get; set; }
        public decimal Preco { get; set; }
    }
}
