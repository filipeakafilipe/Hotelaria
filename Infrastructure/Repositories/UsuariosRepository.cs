using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class UsuariosRepository : BaseRepository, IRepository<Usuarios>
    {
        public void Adicionar(Usuarios entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Usuarios entidade)
        {
            throw new NotImplementedException();
        }

        public Usuarios Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
