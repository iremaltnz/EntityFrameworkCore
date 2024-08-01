// See https://aka.ms/new-console-template for more information

using EntityFrameworkCore.CodeFirst;
using EntityFrameworkCore.CodeFirst.DAL;
using EntityFrameworkCore.CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{

    // Eager Loading
    // id=3 olan category ve ona bağlı productlar

    //var categorWithProduct = _context.Categories
    //    .Include(x => x.Products)
    //    .Where(x => x.Id == 3);

    // id=3 olan category ve ona bağlı productlar ve productfeatures bilgisi

    //var categorWithProductProductFeatures = _context.Categories
    //.Include(x => x.Products)
    //.ThenInclude(x=>x.ProductFeature)
    //.Where(x => x.Id == 3);

    //Explict Loading

    //var category=_context.Categories.FirstOrDefault();

    //if (category != null)
    //{
    //    _context.Entry(category)
    //       .Collection(x => x.Products)
    //       .Load();
    //}

    //var product=_context.Products.FirstOrDefault();
    //if (product != null) 
    //{ 
    //    _context.Entry(product)
    //        .Reference(x=>x.ProductFeature)
    //        .Load();
    //}

    // Lazy Loading

    var category=await _context.Categories.FirstAsync();

    Console.WriteLine("Category çekildi");

    var products = category.Products;

    Console.WriteLine("...");






    // one-to-many

    //var category = new Category { Name = "Kalem" };

    //var product = new Product { Name = "Kurşun Kalem", Price = 40, Stock = 20, Barcode = 111, Category = category };

    //_context.Products.Add(product);

    //category.Products.Add(new Product { Name = "Pilot Kalem", Price = 700, Stock = 30, Barcode = 214 });

    //_context.Add(category);


    // one-to-one 
    //product tablosunda olup pf tablosunda data aolmayabilir ama tam tersi olamaz !!
    //var category = new Category { Name = "Silgi" };
    //var product = new Product { Name = "Kokulu Silgi", Price = 200, Stock = 10, Barcode = 175,CategoryId=3, ProductFeature=new() {Color="Pembe",Height=100,Width=100 } };


    //_context.Products.Add(product);

    //many-to-many
    //var student=new Student() { Name="İrem"};

    //student.Teachers.Add(new Teacher() { Name = "Şeyda" });
    //student.Teachers.Add(new Teacher() { Name = "Kemal" });

    //var teacher = new Teacher() {Name="Anıl" ,Students=new List<Student>() 
    //{
    //  new Student(){Name="Lale"},
    //  new Student(){Name="Samet"}
    //} };

    //_context.Add(teacher);
    //_context.SaveChanges();











    //var product = _context.Products.First();

    //product.Name = "Test";
    //product.Price = 10;

    // Track edilmiş bir datada bir propda değişiklik yaptın 
    // Ef direkt statei modify'a çekiyor
    // update metotunu çağırmana gerek yok.

    // _context.Update(product); 
    //_context.SaveChanges();

    //_context.Products.Add(new Product { Name="Kalem 1",Price=50,Stock=150,Barcode=123456789});

    //_context.Products.Add(new Product { Name = "Kalem 2", Price = 50, Stock = 150, Barcode = 123456788 });

    //_context.Products.Add(new Product { Name = "Kalem 3", Price = 50, Stock = 150, Barcode = 123456787 });

    //// Loglamalarda kullanabılır. Birden fazla database kullanabiliriz. DbContext'in idsini verir
    //Console.WriteLine($"ContextId : {_context.ContextId}");

    //_context.SaveChanges();

    // AsNoTracking() -> Gelen datalar ef core tarafından track edilmesin ! Memoryde tutulmaz.

    //Güncelleme yapılan durumlarda toList kullanmak sıkıntı yaratır.

    // Change Tracker ef core tarafından track edilen datalara erişmemizi sağlar 

    //var products=await _context.Products.ToListAsync();


    //_context.ChangeTracker.Entries().ToList().ForEach(e =>
    //{
    //    if (e.Entity is Product product)
    //    {
    //        // dönüştürebiliyormu datayı ?
    //        // dönüştürürse true döner ve product nesnesine atar

    //        product.Stock += 100;
    //    }
    //});
    //_context.SaveChanges();


    //var newProduct = new Product { Name = "NoteBook", Price = 75, Stock = 70, Barcode = 25369 };

    //Console.WriteLine($"First State : {_context.Entry(newProduct).State}");

    //_context.Add(newProduct);
    //Console.WriteLine($"State : {_context.Entry(newProduct).State}");

    //_context.SaveChanges();
    //Console.WriteLine($"State after savechanges : {_context.Entry(newProduct).State}");

    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"State : {state}");
    //});
}
