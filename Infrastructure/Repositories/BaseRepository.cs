using Hotelaria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected HotelariaContext db;

        public BaseRepository()
        {
            db = new HotelariaContext();
        }
    }
}
