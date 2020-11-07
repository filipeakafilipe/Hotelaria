using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ComandaUsuarioExcluidoNotification : INotification
    {
        public int Id { get; set; }
    }
}
