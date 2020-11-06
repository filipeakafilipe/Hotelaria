using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotelaria.Infrastructure.Mapping;

namespace Hotelaria.Infrastructure.Repositories
{
    public class UsuariosRepository : BaseRepository, IRepository<UsuarioVO>
    {
        public void Adicionar(UsuarioVO entidadeVO)
        {
            var entidade = mapper.Map<Usuario>(entidadeVO);

            db.Usuarios.Add(entidade);

            db.SaveChanges();
        }

        public void Atualizar(int id, UsuarioVO entidade)
        {
            throw new NotImplementedException();
        }

        public UsuarioVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
