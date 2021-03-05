using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Models;

namespace ProjectShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext(DbContextOptions<ProductShopContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tøjtype> Tøjtyper { get; set; }
        public DbSet<Kvinde> Kvinder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Tøjtype>().ToTable("Tøjtype");
            modelBuilder.Entity<Kvinde>().ToTable("Kvinde");
            
        }

        
    }

        
    
}
