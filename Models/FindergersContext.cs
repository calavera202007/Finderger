using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Findergers.Models
{
    public partial class FindergersContext : DbContext
    {
        public FindergersContext()
        {
        }

        public FindergersContext(DbContextOptions<FindergersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desaparecido> Desaparecidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=KEVIN_DESKTOP\\SQLEXPRESS; database=Findergers; integrated security=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desaparecido>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDesaparicion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
