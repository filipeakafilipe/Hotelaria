using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Domain.Interfaces
{
    public interface IUsuariosRepository<T> : IRepository<T>
    {
        T GetByLogin(string login);
        List<T> Get(string cpf);
    }
}
