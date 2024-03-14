// See https://aka.ms/new-console-template for more information

using EntityFrameworkCore.CodeFirst;
using EntityFrameworkCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    // Neden using ?
    // İşlem bittiğinde dbcontext memoryden dipose olsun

    // best practice async ile çalışmak 
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine(p.Name);
    });
}
