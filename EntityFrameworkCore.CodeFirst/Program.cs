// See https://aka.ms/new-console-template for more information

using EntityFrameworkCore.CodeFirst;
using EntityFrameworkCore.CodeFirst.DAL;
using EntityFrameworkCore.CodeFirst.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var newProduct = new Product { Name = "NoteBook", Price = 75, Stock = 70, Barcode = 25369 };

    Console.WriteLine($"First State : {_context.Entry(newProduct).State}");

    _context.Add(newProduct);
    Console.WriteLine($"State : {_context.Entry(newProduct).State}");

    _context.SaveChanges();
    Console.WriteLine($"State after savechanges : {_context.Entry(newProduct).State}");

    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"State : {state}");
    //});
}
