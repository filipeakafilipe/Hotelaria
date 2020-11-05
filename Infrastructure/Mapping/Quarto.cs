using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotelaria.Infrastructure.Mapping
{
    public class Quarto
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
