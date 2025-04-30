using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Models
{
    public class Department
    {
        public string? Name { get; set; }
        public List<Employee>? Employees { get; set; }
        public decimal Budget { get; set; }
    }
}
