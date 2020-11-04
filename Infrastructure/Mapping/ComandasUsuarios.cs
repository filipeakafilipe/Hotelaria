using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public partial class ComandasUsuarios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}
