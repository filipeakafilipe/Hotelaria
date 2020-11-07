using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ServicoExcluidoNotification : INotification
    {
        public int Id { get; set; }
    }
}
