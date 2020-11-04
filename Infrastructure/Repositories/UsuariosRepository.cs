using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Usuarios> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
