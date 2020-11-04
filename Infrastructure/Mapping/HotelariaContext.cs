using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hotelaria.Infrastructure.Mapping
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

        public virtual DbSet<Comandas> Comandas { get; set; }
        public virtual DbSet<ComandasServicos> ComandasServicos { get; set; }
        public virtual DbSet<ComandasUsuarios> ComandasUsuarios { get; set; }
        public virtual DbSet<Quartos> Quartos { get; set; }
        public virtual DbSet<Servicos> Servicos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=Hotelaria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comandas>(entity =>
            {
                entity.Property(e => e.DataAbertura).HasColumnType("datetime");

                entity.Property(e => e.DataEncerramento).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<ComandasServicos>(entity =>
            {
                entity.HasOne(d => d.Servico)
                    .WithMany(p => p.ComandasServicos)
                    .HasForeignKey(d => d.ServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ComandasS__Quant__2E1BDC42");
            });

            modelBuilder.Entity<ComandasUsuarios>(entity =>
            {
                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ComandasUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ComandasU__Usuar__2B3F6F97");
            });

            modelBuilder.Entity<Quartos>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Preco).HasColumnType("money");
            });

            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Observacoes)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Preco).HasColumnType("money");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
