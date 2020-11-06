using AutoMapper;
using Hotelaria.Application.Models;
using Hotelaria.Infrastructure.Context;
using Hotelaria.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotelaria.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected HotelariaContext db;
        protected Mapper mapper;

        public BaseRepository()
        {
            db = new HotelariaContext();

            var config = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Usuario, UsuarioVO>();
                cfg.CreateMap<UsuarioVO, Usuario>();
                });

            mapper = new Mapper(config);
        }
    }
}
