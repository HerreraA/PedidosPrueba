using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PedidosPrueba.Core.Entidades;

namespace PedidosPrueba.Infraestructure.Datos
{
    public partial class PedidosPruebaContext : DbContext
    {
        public PedidosPruebaContext()
        {
        }

        public PedidosPruebaContext(DbContextOptions<PedidosPruebaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.200;Database=PedidosPrueba;User Id=sa;Password=Sa123456;");
            }
        }


        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__PEDIDOS__9D335DC39F20AD06");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPedido).HasColumnType("date");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioCreacionNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuarioCreacion)
                    .HasConstraintName("FK__PEDIDOS__IdUsuar__403A8C7D");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__5B65BF9789E6F3C0");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioLogin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
