using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasServicosRepository : BaseRepository, IRepository<ComandasServicos>
    {
        public void Adicionar(ComandasServicos entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ComandasServicos entidade)
        {
            throw new NotImplementedException();
        }

        public ComandasServicos Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComandasServicos> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
