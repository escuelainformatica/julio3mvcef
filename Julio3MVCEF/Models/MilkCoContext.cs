using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PCJC\\SQLDEV;Initial Catalog=MilkCo;Integrated Security=True");
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
