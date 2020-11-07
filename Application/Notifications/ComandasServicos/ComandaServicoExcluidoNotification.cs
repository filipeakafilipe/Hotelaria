using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ComandaServicoExcluidoNotification : INotification
    {
        public int Id { get; set; }
    }
}
