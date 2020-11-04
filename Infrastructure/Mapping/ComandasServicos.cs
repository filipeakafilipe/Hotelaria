using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public partial class ComandasServicos
    {
        public int Id { get; set; }
        public int ServicoId { get; set; }
        public int Quantidade { get; set; }

        public virtual Servicos Servico { get; set; }
    }
}
