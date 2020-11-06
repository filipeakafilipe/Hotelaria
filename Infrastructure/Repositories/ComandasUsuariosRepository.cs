using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasUsuariosRepository : BaseRepository, IRepository<ComandasUsuarios>
    {
        public void Adicionar(ComandasUsuarios entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ComandasUsuarios entidade)
        {
            throw new NotImplementedException();
        }

        public ComandasUsuarios Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComandasUsuarios> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
