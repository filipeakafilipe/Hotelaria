using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ComandaUsuarioCriadoNotification : INotification
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
