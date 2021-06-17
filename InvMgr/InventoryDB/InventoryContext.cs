using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryDB
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Inventory;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.cost).HasColumnName("cost");

                entity.Property(e => e.createDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.location)
                    .HasColumnName("location")
                    .HasMaxLength(256);

                entity.Property(e => e.price).HasColumnName("price");

                entity.Property(e => e.quantity).HasColumnName("quantity");
            });
        }
    }
}
