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
    public class ComandasUsuariosRepository : BaseRepository, IComandasUsuariosRepository<ComandasUsuariosVO>
    {
        public void Adicionar(ComandasUsuariosVO entidadeVO)
        {
            db.ComandasUsuarios.Add(mapper.Map<ComandasUsuarios>(entidadeVO));

            db.SaveChanges();
        }

        public void Atualizar(int id, ComandasUsuariosVO entidadeVO)
        {
            var comandaUsuario = mapper.Map<ComandasUsuarios>(Get(id));

            if (comandaUsuario != null)
            {
                comandaUsuario.Comanda = mapper.Map<Comanda>(entidadeVO.Comanda);
                comandaUsuario.Usuario = mapper.Map<Usuario>(entidadeVO.Usuario);
                comandaUsuario.ComandaId = entidadeVO.ComandaId;
                comandaUsuario.UsuarioId = entidadeVO.UsuarioId;

                db.Entry(comandaUsuario).State = EntityState.Modified;

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ComandasUsuariosVO Get(int id)
        {
            return mapper.Map<ComandasUsuariosVO>(db.ComandasUsuarios.Include(c => c.Comanda).Include(c => c.Usuario).AsNoTracking().FirstOrDefault(c => c.Id == id));
        }

        public List<ComandasUsuariosVO> GetAll()
        {
            return mapper.Map<List<ComandasUsuariosVO>>(db.ComandasUsuarios.Include(c => c.Comanda).Include(c => c.Usuario).ToList());
        }

        public void Remover(int id)
        {
            var comandaUsuario = mapper.Map<ComandasUsuarios>(Get(id));

            if (comandaUsuario != null)
            {
                db.ComandasUsuarios.Remove(comandaUsuario);

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
