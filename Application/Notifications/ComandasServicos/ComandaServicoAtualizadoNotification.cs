using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ComandaServicoAtualizadoNotification : INotification
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ComandaId { get; set; }
        public int ServicoId { get; set; }
    }
}
