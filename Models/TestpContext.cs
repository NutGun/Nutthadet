using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace workshop.Models
{
    public partial class TestpContext : DbContext
    {
        public TestpContext()
        {
        }

        public TestpContext(DbContextOptions<TestpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catategory> Catategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Titel> Titels { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catategory>(entity =>
            {
                entity.Property(e => e.CatId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NameCat).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CustType).IsUnicode(false);

                entity.Property(e => e.InitialCode).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CustTypeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustType)
                    .HasConstraintName("FK_T_Customer_T_Type");

                entity.HasOne(d => d.InitialCodeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.InitialCode)
                    .HasConstraintName("FK_T_Customer_T_Titel");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Qty).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_T_Product_T_Catategory");

                entity.HasOne(d => d.UnitCodeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitCode)
                    .HasConstraintName("FK_T_Product_T_Unit");
            });

            modelBuilder.Entity<Titel>(entity =>
            {
                entity.Property(e => e.InitialCode)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InitialName).IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.CustType)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.UnitCode)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NameUnit).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
