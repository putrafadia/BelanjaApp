using KatalogProduk.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Data
{
    public class KatalogProdukContext : DbContext
    {
        public KatalogProdukContext()
        {

        }
        public KatalogProdukContext(DbContextOptions<KatalogProdukContext> opt) : base(opt)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Produk> Produks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("InMem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasMany(p=>p.Produks)
            .WithOne(p=>p.Category)
            .HasForeignKey(p=>p.CategoryId);

            modelBuilder.Entity<Produk>()
            .HasOne(c=>c.Category)
            .WithMany(c=>c.Produks)
            .HasForeignKey(c=>c.CategoryId);
        }
    }
}
