﻿using Hotelaria.Domain.Interfaces;
using Hotelaria.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Infrastructure.Repositories
{
    public class ComandasServicosRepository : BaseRepository, IComandasServicosRepository<ComandasServicosVO>
    {
        public void Adicionar(ComandasServicosVO entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, ComandasServicosVO entidade)
        {
            throw new NotImplementedException();
        }

        public ComandasServicosVO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComandasServicosVO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
