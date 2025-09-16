using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingInheritance.Data.Models
{
    internal class PartTimeEmployee : Employee
    {
        public int CountOfHrs { get; set; }
        public decimal HourRate { get; set; }
    }
}
