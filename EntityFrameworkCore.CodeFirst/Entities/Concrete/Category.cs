using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // null exception almamak içim newledik
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
