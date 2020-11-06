using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ServicosRepository : BaseRepository, IRepository<Servico>
    {
        public void Adicionar(Servico entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Servico entidade)
        {
            throw new NotImplementedException();
        }

        public Servico Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Servico> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
