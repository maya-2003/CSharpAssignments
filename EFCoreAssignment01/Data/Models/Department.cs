using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Data.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Ins_Id { get; set; }
        public Instructor? Head { get; set; }
        public DateTime HiringDate { get; set; }
        public List<Instructor> instructors { get; set; }
    }
}
