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
    public class ComandasUsuariosRepository : BaseRepository, IRepository<ComandasUsuariosVO>
    {
        public void Adicionar(ComandasUsuariosVO entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ComandasUsuariosVO entidade)
        {
            throw new NotImplementedException();
        }

        public ComandasUsuariosVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComandasUsuariosVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
