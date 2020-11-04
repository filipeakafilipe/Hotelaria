using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasRepository : BaseRepository, IRepository<Comandas>
    {
        public void Adicionar(Comandas entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Comandas entidade)
        {
            throw new NotImplementedException();
        }

        public Comandas Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
