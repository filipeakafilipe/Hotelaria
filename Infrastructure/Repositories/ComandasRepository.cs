using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasRepository : BaseRepository, IRepository<Comanda>
    {
        public void Adicionar(Comanda entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Comanda entidade)
        {
            throw new NotImplementedException();
        }

        public Comanda Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comanda> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
