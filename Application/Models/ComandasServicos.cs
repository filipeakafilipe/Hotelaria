using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Models
{
    public class ComandasServicos
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Comanda Comanda { get; set; }
        public Servico Servico { get; set; }
    }
}
