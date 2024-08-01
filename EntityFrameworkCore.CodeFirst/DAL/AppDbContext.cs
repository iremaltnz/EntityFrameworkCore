using EntityFrameworkCore.CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.DAL
{
    public class AppDbContext:DbContext
    {
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeatures { get; set; }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }

        public DbSet<BasePerson> Persons { get; set; }
        public DbSet<Manager>  Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();

            // lazy loading aktif
            // information ve üstünü logla

            optionsBuilder
                //.LogTo(Console.WriteLine,LogLevel.Information)
                //.UseLazyLoadingProxies()
                .UseSqlServer(Initializer.Configuration.GetConnectionString("SqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            //one-to-one
            // modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            //many-to-many
            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, string>>(
            //    "StudentTeacherManyToMany" ,
            //    x=>x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK_Teacherid"),
            //    x=>x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK_Studentid")
            //    );

            base.OnModelCreating(modelBuilder);
        }

        //public override int SaveChanges()
        //{
        //    ChangeTracker.Entries().ToList().ForEach(e =>
        //    {
        //        if (e.Entity is Product product)
        //        {
        //            // dönüştürebiliyormu datayı ?
        //            // dönüştürürse true döner ve product nesnesine atar

        //            if (e.State == EntityState.Added)
        //            {
        //                product.CreatedDate = DateTime.Now;
        //            }
        //        }
        //    });

        //    return base.SaveChanges();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Fluent API
        //    modelBuilder.Entity<Product>().ToTable("ProductTbb","productstbb");
        //    base.OnModelCreating(modelBuilder); 
        //}
    }
}
