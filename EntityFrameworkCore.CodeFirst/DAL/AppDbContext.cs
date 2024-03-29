﻿using EntityFrameworkCore.CodeFirst.Entities.Concrete;
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
            // Nesne örneği alsın , conf dosyası hazır hale gelir connection string okunur. 

            // Bunları sadece console uyg yapıyoruz. Web vs zaten hazır geliyor

            Initializer.Build();

            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }
    }
}
