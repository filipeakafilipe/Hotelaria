﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Adicionar(T entidade);
        void Remover(int id);
        void Atualizar(int id, T entidade);
        List<T> GetAll();
    }
}
