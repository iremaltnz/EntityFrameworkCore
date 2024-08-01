using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.Entities.Concrete
{
    public class Manager
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int Grade { get; set; }
    }
}
