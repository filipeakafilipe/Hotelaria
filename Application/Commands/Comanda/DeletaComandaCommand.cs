using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Commands
{
    public class DeletaComandaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
