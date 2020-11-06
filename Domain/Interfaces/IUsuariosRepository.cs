using System;
using System.Collections.Generic;
using System.Text;

namespace Hotelaria.Domain.Interfaces
{
    public interface IUsuariosRepository<T> : IRepository<T>
    {
        List<T> Get(string cpf);
    }
}
