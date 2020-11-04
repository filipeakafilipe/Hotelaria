using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Domain.Interfaces
{
    public interface IRepository<T>
    {
        public T Get(int id);
        void Adicionar(T entidade);
        void Remover(int id);
        void Atualizar(int id, T entidade);
        public IEnumerable<T> GetAll();
    }
}
