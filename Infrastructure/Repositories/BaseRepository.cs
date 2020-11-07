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
                cfg.CreateMap<Servico, ServicoVO>();
                cfg.CreateMap<ServicoVO, Servico>();
                cfg.CreateMap<Quarto, QuartoVO>();
                cfg.CreateMap<QuartoVO, Quarto>();
                cfg.CreateMap<Comanda, ComandaVO>();
                cfg.CreateMap<ComandaVO, Comanda>();
                cfg.CreateMap<ComandasServicos, ComandasServicosVO>();
                cfg.CreateMap<ComandasServicosVO, ComandasServicos>();
                cfg.CreateMap<ComandasUsuarios, ComandasUsuariosVO>();
                cfg.CreateMap<ComandasUsuariosVO, ComandasUsuarios>();
                });

            mapper = new Mapper(config);
        }
    }
}
