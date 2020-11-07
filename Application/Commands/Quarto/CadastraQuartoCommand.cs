using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Commands
{
    public class CadastraQuartoCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
