using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class QuartosRepository : BaseRepository, IRepository<Quarto>
    {
        public void Adicionar(Quarto entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Quarto entidade)
        {
            throw new NotImplementedException();
        }

        public Quarto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quarto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
