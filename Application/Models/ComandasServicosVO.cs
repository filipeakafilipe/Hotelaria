using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Models
{
    public class ComandasServicosVO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public ComandaVO Comanda { get; set; }
        public ServicoVO Servico { get; set; }
    }
}
