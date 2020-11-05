using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class UsuariosRepository : BaseRepository, IRepository<Usuario>
    {
        public void Adicionar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
