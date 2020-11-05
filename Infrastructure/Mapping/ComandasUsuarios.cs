using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public class ComandasUsuarios
    {
        public int Id { get; set; }

        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
