using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.Entities.Concrete
{
    public class Employee:BasePerson
    {
        public int Salary { get; set; }
    }
}
