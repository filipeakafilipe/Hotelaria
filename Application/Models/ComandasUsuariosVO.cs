using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Application.Models
{
    public class ComandasUsuariosVO
    {
        public int Id { get; set; }
        public ComandaVO Comanda { get; set; }
        public UsuarioVO Usuario { get; set; }
    }
}
