using EntityFrameworkCore.CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();

            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Product product)
                {
                    // dönüştürebiliyormu datayı ?
                    // dönüştürürse true döner ve product nesnesine atar

                    if (e.State == EntityState.Added)
                    {
                        product.CreatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Product>().ToTable("ProductTbb","productstbb");
            base.OnModelCreating(modelBuilder); 
        }
    }
}
