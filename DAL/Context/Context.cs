using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            
            // .UseSqlServer(@"Server=.\SQLEXPRESS;Database=KlassyCafe;Integrated Security=True;");
            .UseNpgsql(@"Server=localhost;Port=5432;Database=KlassyCafe;UserId=postgres;Password=Admin123;");
            
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}