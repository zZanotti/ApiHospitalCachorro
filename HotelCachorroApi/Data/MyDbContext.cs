using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelCachorroApi.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCachorro> TbCachorros { get; set; } = null!;
        public virtual DbSet<TbCheckin> TbCheckins { get; set; } = null!;
        public virtual DbSet<TbCliente> TbClientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=db_hotel_cachorro", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbCachorro>(entity =>
            {
                entity.HasKey(e => e.IdCachorro)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cachorro");

                entity.HasIndex(e => e.IdCliente, "fk_tbcachorro_idcliente");

                entity.Property(e => e.IdCachorro).HasColumnName("id_cachorro");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Peso)
                    .HasPrecision(10)
                    .HasColumnName("peso");

                entity.Property(e => e.Porte)
                    .HasMaxLength(20)
                    .HasColumnName("porte");

                entity.Property(e => e.Raca)
                    .HasMaxLength(30)
                    .HasColumnName("raca");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbCachorros)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_tbcachorro_idcliente");
            });

            modelBuilder.Entity<TbCheckin>(entity =>
            {
                entity.HasKey(e => e.IdChekin)
                    .HasName("PRIMARY");

                entity.ToTable("tb_checkin");

                entity.HasIndex(e => e.IdCachorro, "fk_tbcheckin_tbcachorro");

                entity.HasIndex(e => e.IdCliente, "fk_tbcheckin_tbcliente");

                entity.Property(e => e.IdChekin).HasColumnName("id_chekin");

                entity.Property(e => e.DataEntrada).HasColumnName("data_entrada");

                entity.Property(e => e.DataSaida).HasColumnName("data_saida");

                entity.Property(e => e.IdCachorro).HasColumnName("id_cachorro");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdCachorroNavigation)
                    .WithMany(p => p.TbCheckins)
                    .HasForeignKey(d => d.IdCachorro)
                    .HasConstraintName("fk_tbcheckin_tbcachorro");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbCheckins)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_tbcheckin_tbcliente");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(100)
                    .HasColumnName("sobrenome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
