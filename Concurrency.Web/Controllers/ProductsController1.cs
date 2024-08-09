using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Controllers
{
    public class ProductsController1 : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController1(AppDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> List(int id)
        {
            
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var exceptionEntry=exception.Entries.First();

                var currentProduct = exceptionEntry.Entity as Product;
                var databaseValues=exceptionEntry.GetDatabaseValues();

             
                var clientValues = exceptionEntry.CurrentValues;

                if (databaseValues==null) 
                {
                    ModelState.AddModelError(string.Empty,"Bu ürün başkası tarafındna silinmiş");
                }
                else
                {
                    var databaseProduct = databaseValues.ToObject() as Product;
                    ModelState.AddModelError(string.Empty, "Bu ürün başkası tarafındna güncellendi");
                }

                return View(product);
            }

        }
    }
}
