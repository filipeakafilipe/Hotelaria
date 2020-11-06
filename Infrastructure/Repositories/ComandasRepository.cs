using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasRepository : BaseRepository, IComandasRepository<ComandaVO>
    {
        public void Adicionar(ComandaVO entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ComandaVO entidade)
        {
            throw new NotImplementedException();
        }

        public ComandaVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComandaVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
