using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ServicosRepository : BaseRepository, IRepository<ServicoVO>
    {
        public void Adicionar(ServicoVO entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ServicoVO entidade)
        {
            throw new NotImplementedException();
        }

        public ServicoVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicoVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
