using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class QuartoAtualizadoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
