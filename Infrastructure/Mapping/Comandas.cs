using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public partial class Comandas
    {
        public int Id { get; set; }
        public int Dias { get; set; }
        public bool Ativa { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataEncerramento { get; set; }
        public decimal Total { get; set; }
    }
}
