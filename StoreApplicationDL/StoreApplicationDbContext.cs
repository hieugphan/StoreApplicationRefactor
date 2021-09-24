using System;
using Microsoft.EntityFrameworkCore;
using StoreApplicationEntities;

namespace StoreApplicationDL
{
    public class StoreApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Store { get; set; }

        public StoreApplicationDbContext(): base()
        {
        }

        public StoreApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        //{
        //    p_options.UseNpgsql(@"Server=chunee.db.elephantsql.com;database=bnriaivc;UserID=bnriaivc;Password=1aO2hKJT8svJEwwp3WeY4SG86RjU1xdh");
        //}

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Stock>()
                .Property(invt => invt.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(li => li.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(ord => ord.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Product>()
                .Property(prod => prod.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Store>()
                .Property(sf => sf.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
