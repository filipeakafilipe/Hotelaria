﻿using Hotelaria.Domain.Interfaces;
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
    public class ServicosRepository : BaseRepository, IServicosRepository<ServicoVO>
    {
        public void Adicionar(ServicoVO entidadeVO)
        {
            db.Servicos.Add(mapper.Map<Servico>(entidadeVO));

            db.SaveChanges();
        }

        public void Atualizar(int id, ServicoVO entidadeVO)
        {
            var servico = mapper.Map<Servico>(Get(id));

            if (servico != null)
            {
                servico.Nome = entidadeVO.Nome;
                servico.Observacoes = entidadeVO.Observacoes;
                servico.Preco = entidadeVO.Preco;

                db.Entry(servico).State = EntityState.Modified;

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public ServicoVO Get(int id)
        {
            return mapper.Map<ServicoVO>(db.Servicos.AsNoTracking().FirstOrDefault(s => s.Id == id));
        }

        public List<ServicoVO> GetAll()
        {
            return mapper.Map<List<ServicoVO>>(db.Servicos.ToList());
        }

        public void Remover(int id)
        {
            var servico = mapper.Map<Servico>(Get(id));

            if (servico != null)
            {
                db.Servicos.Remove(servico);

                db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
