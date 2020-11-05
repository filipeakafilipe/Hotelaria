using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public class ComandasServicos
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }

        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
