using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class MochaMomentDBContext : DbContext
    {
        public MochaMomentDBContext()
        {
        }

        public MochaMomentDBContext(DbContextOptions<MochaMomentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customerID");

                entity.Property(e => e.Birthdate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("birthdate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.MailAddress)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("mailAddress");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("inventoryID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__inventory__locat__6A30C649");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__inventory__produ__6B24EA82");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("lineItem");

                entity.Property(e => e.LineItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("lineItemID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__lineItem__orderI__66603565");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__lineItem__produc__6754599E");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("locationID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("storeName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.LocationId).HasColumnName("locationID");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__orders__customer__6383C8BA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__orders__location__628FA481");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("itemName");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
