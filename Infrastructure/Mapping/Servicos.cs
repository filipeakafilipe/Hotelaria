using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public partial class Servicos
    {
        public Servicos()
        {
            ComandasServicos = new HashSet<ComandasServicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacoes { get; set; }
        public decimal Preco { get; set; }

        public virtual ICollection<ComandasServicos> ComandasServicos { get; set; }
    }
}
