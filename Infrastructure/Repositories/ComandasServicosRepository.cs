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
    public class ComandasServicosRepository : BaseRepository, IComandasServicosRepository<ComandasServicosVO>
    {
        public void Adicionar(ComandasServicosVO entidadeVO)
        {
            db.ComandasServicos.Add(mapper.Map<ComandasServicos>(entidadeVO));

            db.SaveChanges();
        }

        public void Atualizar(int id, ComandasServicosVO entidadeVO)
        {
            var comandaServico = mapper.Map<ComandasServicos>(Get(id));

            if (comandaServico != null)
            {
                comandaServico.Comanda = mapper.Map<Comanda>(entidadeVO.Comanda);
                comandaServico.Servico = mapper.Map<Servico>(entidadeVO.Servico);
                comandaServico.ComandaId = entidadeVO.ComandaId;
                comandaServico.ServicoId = entidadeVO.ServicoId;
                comandaServico.Quantidade = entidadeVO.Quantidade;

                db.Entry(comandaServico).State = EntityState.Modified;

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ComandasServicosVO Get(int id)
        {
            return mapper.Map<ComandasServicosVO>(db.ComandasServicos.Include(c => c.Comanda).Include(c => c.Servico).AsNoTracking().FirstOrDefault(c => c.Id == id));
        }

        public List<ComandasServicosVO> GetAll()
        {
            return mapper.Map<List<ComandasServicosVO>>(db.ComandasServicos.Include(c => c.Comanda).Include(c => c.Servico).ToList());
        }

        public void Remover(int id)
        {
            var comandaServico = mapper.Map<ComandasServicos>(Get(id));

            if (comandaServico != null)
            {
                db.ComandasServicos.Remove(comandaServico);

                db.SaveChanges();
            }
        }
    }
}
