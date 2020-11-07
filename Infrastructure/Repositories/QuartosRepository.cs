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
    public class QuartosRepository : BaseRepository, IQuartosRepository<QuartoVO>
    {
        public void Adicionar(QuartoVO entidadeVO)
        {
            db.Quartos.Add(mapper.Map<Quarto>(entidadeVO));

            db.SaveChanges();
        }

        public void Atualizar(int id, QuartoVO entidadeVO)
        {
            var quarto = mapper.Map<Quarto>(Get(id));

            quarto.Nome = entidadeVO.Nome;
            quarto.Preco = entidadeVO.Preco;

            db.Entry(quarto).State = EntityState.Modified;

            db.SaveChanges();
        }

        public QuartoVO Get(int id)
        {
            return mapper.Map<QuartoVO>(db.Quartos.FirstOrDefault(q => q.Id == id));
        }

        public List<QuartoVO> GetAll()
        {
            return mapper.Map<List<QuartoVO>>(db.Quartos.ToList());
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
