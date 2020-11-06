using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Models
{
    public class ComandasUsuarios
    {
        public int Id { get; set; }
        public Comanda Comanda { get; set; }
        public Usuario Usuario { get; set; }
    }
}
