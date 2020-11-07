using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Notifications
{
    public class ComandaAtualizadaNotification : INotification
    {
        public int Id { get; set; }
        public int Dias { get; set; }
        public bool Ativa { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataEncerramento { get; set; }
        public decimal Total { get; set; }
    }
}
