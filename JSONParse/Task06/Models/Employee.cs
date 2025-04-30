using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public DateOnly HireDate { get; set; }
        public decimal Salary { get; set; }
        public List<string>? Skills { get; set; }
        public Dictionary<string, string>? Contacts { get; set; }
        public bool IsActive { get; set; }
    }
}
