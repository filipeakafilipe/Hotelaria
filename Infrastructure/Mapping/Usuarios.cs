using System;
using System.Collections.Generic;

namespace Hotelaria.Infrastructure.Mapping
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            ComandasUsuarios = new HashSet<ComandasUsuarios>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<ComandasUsuarios> ComandasUsuarios { get; set; }
    }
}
