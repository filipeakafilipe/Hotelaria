using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ServicoCriadoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacoes { get; set; }
        public decimal Preco { get; set; }
    }
}
