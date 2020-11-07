using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hotelaria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasRepository : BaseRepository, IComandasRepository<ComandaVO>
    {
        public void Adicionar(ComandaVO entidadeVO)
        {
            db.Comandas.Add(mapper.Map<Comanda>(entidadeVO));

            db.SaveChanges();
        }

        public void Atualizar(int id, ComandaVO entidadeVO)
        {
            var comanda = mapper.Map<Comanda>(Get(id));

            if (comanda != null)
            {
                comanda.Ativa = entidadeVO.Ativa;
                comanda.DataAbertura = entidadeVO.DataAbertura;
                comanda.DataEncerramento = entidadeVO.DataEncerramento;
                comanda.Dias = entidadeVO.Dias;

                db.Entry(comanda).State = EntityState.Modified;

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ComandaVO Get(int id)
        {
            return mapper.Map<ComandaVO>(db.Comandas.AsNoTracking().FirstOrDefault(c => c.Id == id));
        }

        public List<ComandaVO> GetAll()
        {
            return mapper.Map<List<ComandaVO>>(db.Comandas.ToList());
        }

        public void Remover(int id)
        {
            var quarto = mapper.Map<Quarto>(Get(id));

            if (quarto != null)
            {
                db.Quartos.Remove(quarto);

                db.SaveChanges();
            }
        }
    }
}
