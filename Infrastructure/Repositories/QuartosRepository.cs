using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class QuartosRepository : BaseRepository, IQuartosRepository<QuartoVO>
    {
        public void Adicionar(QuartoVO entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, QuartoVO entidade)
        {
            throw new NotImplementedException();
        }

        public QuartoVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuartoVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
