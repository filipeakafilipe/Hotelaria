using Hotelaria.Domain.Interfaces;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ServicosRepository : BaseRepository, IRepository<Servicos>
    {
        public void Adicionar(Servicos entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Servicos entidade)
        {
            throw new NotImplementedException();
        }

        public Servicos Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
