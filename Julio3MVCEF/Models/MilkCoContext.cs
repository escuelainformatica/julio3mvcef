using System;
using Julio3MVCEF.configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Julio3MVCEF.Models
{
    public partial class MilkCoContext : DbContext
    {
        public MilkCoContext()
        {
        }

        public MilkCoContext(DbContextOptions<MilkCoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuracion.Conexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PK__Cities__814F31DE8C0B3B34");

                entity.HasComment("MIT License https://github.com/EFTEC/MilkCo-Database");

                entity.Property(e => e.IdCity).ValueGeneratedNever();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__Customer__D05876867DEDAE5B");

                entity.HasComment("MIT License https://github.com/EFTEC/MilkCo-Database");

                entity.Property(e => e.IdCustomer).ValueGeneratedNever();

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("Customers_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
