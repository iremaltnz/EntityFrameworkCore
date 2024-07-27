// See https://aka.ms/new-console-template for more information

using EntityFrameworkCore.CodeFirst;
using EntityFrameworkCore.CodeFirst.DAL;
using EntityFrameworkCore.CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{

    _context.Products.Add(new Product { Name="Kalem 1",Price=50,Stock=150,Barcode=123456789});

    _context.Products.Add(new Product { Name = "Kalem 2", Price = 50, Stock = 150, Barcode = 123456788 });

    _context.Products.Add(new Product { Name = "Kalem 3", Price = 50, Stock = 150, Barcode = 123456787 });

    // Loglamalarda kullanabılır. Birden fazla database kullanabiliriz. DbContext'in idsini verir
    Console.WriteLine($"ContextId : {_context.ContextId}");

    _context.SaveChanges();

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
