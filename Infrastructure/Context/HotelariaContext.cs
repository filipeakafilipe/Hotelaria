using System;
using System.Configuration;
using Hotelaria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Hotelaria.Infrastructure.Context
{
    public partial class HotelariaContext : DbContext
    {
        public HotelariaContext()
        {
        }

        public HotelariaContext(DbContextOptions<HotelariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comanda> Comandas { get; set; }
        public virtual DbSet<ComandasServicos> ComandasServicos { get; set; }
        public virtual DbSet<ComandasUsuarios> ComandasUsuarios { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=Hotelaria;Integrated Security=True;");
        }
    }
}
