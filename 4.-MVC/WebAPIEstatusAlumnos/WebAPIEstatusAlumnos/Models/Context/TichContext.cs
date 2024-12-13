using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPIEstatusAlumnos.Models.Entities;

namespace WebAPIEstatusAlumnos.Models.Context
{
    public partial class TichContext : DbContext
    {
        public TichContext()
        {
        }

        public TichContext(DbContextOptions<TichContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstatusAlumnos> EstatusAlumnos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstatusAlumnos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
