using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotelaria.Infrastructure.Mapping
{
    public class Servico
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Observacoes { get; set; }
        public decimal Preco { get; set; }
    }
}
