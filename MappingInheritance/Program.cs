using MappingInheritance.Data;
using MappingInheritance.Data.Models;

namespace MappingInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyCompanyContext myCompanyContext = new MyCompanyContext();
            var emp01 = new FullTimeEmployee()
            {
                Name = "Rana",
                Age = 20,
                Address = "Mansoura",
                Salary = 3_000,
                StartDate = DateTime.Now,
            };

            var emp02 = new PartTimeEmployee()
            {
                Name = "Mai",
                Age = 30,
                Address = "Giza",
                CountOfHrs = 15,
                HourRate = 250
            };


            //myCompanyContext.FullTimeEmployees.Add(emp01);
            //myCompanyContext.PartTimeEmployees.Add(emp02);
            //myCompanyContext.SaveChanges();

            //var fullTimeEmp = myCompanyContext.FullTimeEmployees.FirstOrDefault();
            //if(fullTimeEmp is not null)
            //{
            //    Console.WriteLine(fullTimeEmp.Name);
            //}
            var res = myCompanyContext.FullTimeEmployees.ToList();
            if (res is not null)
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"{item.Name} 11 {item.Salary}");
                }
            }
        }
    }
}
