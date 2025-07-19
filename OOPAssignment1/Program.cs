using System.Xml.Linq;

namespace OOPAssignment1
{
    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    enum Season
    {
        Spring, 
        Summer,
        Autumn, 
        Winter
    }

    [Flags]
    enum Permissions: byte
    {

        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8,
    }
    enum Colors
    {
        Red,
        Green,
        Blue
    }

    #region 3- We need to restrict the Gender field to be only M or F [Male or Female] 
    enum Gender { 
        M,
        F
    }
    #endregion

    #region 4- Assign the following security privileges to the employee (guest, Developer, secretary and DBA) in a form of Enum

    [Flags]
    enum Security
    {
        Guest=1, 
        Developer=2, 
        Secretary=4, 
        DBA=8
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            // PART 01
            ///////////////////////////////////////

            #region 1- Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.
            foreach (WeekDays wd in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(wd);
            }
            #endregion

            #region 2- Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
            Person[] persons = new Person[3];
            persons[0] = new Person(21, "Maya");
            persons[1] = new Person(20, "Hana");
            persons[2] = new Person(6, "Lara");
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
            #endregion

            #region 3- Create an enum called "Season" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
            string[][] seasonMonths = new string[][]
            {
                new string[] { "March", "April", "May" },
                new string[] { "June", "July", "August" },
                new string[] { "September", "October", "November" },
                new string[] { "December", "January", "February" }
            };

            object result;
            string seasonName;

            do
            {
                Console.WriteLine("Enter season name:");
                seasonName = Console.ReadLine();

                if (!Enum.TryParse(typeof(Season), seasonName, out result))
                {
                    Console.WriteLine("Invalid season name \n");
                }

            } while (!Enum.TryParse(typeof(Season), seasonName, out result));

            Season season = (Season)result;
            string[] monthsRange = seasonMonths[(int)season];
            Console.WriteLine($"{string.Join(", ", monthsRange)}");
            #endregion

            #region 4- Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission is existed inside variable

            // variable to add and remove permissions
            Permissions perm = Permissions.Delete | Permissions.Write;
            perm ^= Permissions.Write;
            // check if specific Permission is existed inside variable
            bool hasRead = perm.HasFlag(Permissions.Read);
            if (hasRead)
            {
                Console.WriteLine("Reading permisssion is already addedd");
            }
            else
            {
                perm ^= Permissions.Read;
            }
            Console.WriteLine($"Permissions: {perm.ToString()}");
            #endregion

            #region 5- Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
            Console.WriteLine("Enter color name :");
            string color = Console.ReadLine();

            if (Enum.TryParse(typeof(Colors), color, out object res))
            {
                Console.WriteLine($"{color} is a primary color");
            }
            else
            {
                Console.WriteLine($"{color} is not a primary color");
            }
            #endregion

            #region 6- Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
            Console.WriteLine("Enter first point X value:");
            double xVal1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter first point Y value:");
            double yVal1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second point X value:");
            double xVal2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second point Y value:");
            double yVal2 = Convert.ToDouble(Console.ReadLine());
            Point p1 = new Point(xVal1, yVal1);
            Point p2 = new Point(xVal2, yVal2);
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            Console.WriteLine($"Distance = {dist:F2}");
            #endregion

            #region 7- Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            Person[] personsArr = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                string name;
                do
                {
                    Console.WriteLine($"Enter name {i + 1}:");
                    name = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(name));

                Console.WriteLine($"Enter age {i + 1}:");
                int age = Convert.ToInt32(Console.ReadLine());
                persons[i] = new Person(age, name);
            }

            int oldestAge = persons[0].Age;
            int oldestIdx = 0;
            for (int i = 1; i < persons.Length; i++)
            {
                if (persons[i].Age > oldestAge)
                {
                    oldestAge = persons[i].Age;
                    oldestIdx = i;
                }
            }
            Console.WriteLine(persons[oldestIdx]);
            #endregion

            // PART 02
            ///////////////////////////////////////
            #region Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions. (Employee [] EmpArr;)
            Employee[] EmpArr = new Employee[3];
            Security securityOfficer = Security.DBA | Security.Developer | Security.Secretary | Security.Guest;

            EmpArr[0] = new Employee(1, "Maya", Gender.F, Security.DBA, 20000, new HireDate(1, 5, 2023));
            EmpArr[1] = new Employee(2, "Jhon", Gender.M, Security.Guest, 5000, new HireDate(10, 7, 2020));
            EmpArr[2] = new Employee(3, "Alex", Gender.M, securityOfficer, 30000, new HireDate(5, 4, 2025));

            foreach (var employee in EmpArr)
            {
                Console.WriteLine(employee);
            }

            int id;
            do
            {
                Console.Write("Enter ID:");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1);

            string empName;
            do
            {
                Console.Write("Enter Name:");
                empName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(empName));

            Gender gender;
            string genderInput;
            do
            {
                Console.Write("Enter Gender: ");
                genderInput = Console.ReadLine();
            } while (!Enum.TryParse(genderInput, true, out gender));



            Security security;
            string securityInput;

            do
            {
                Console.Write("Enter Security Level: ");
                securityInput = Console.ReadLine();
            } while (!Enum.TryParse<Security>(securityInput, true, out security));

            int salary;
            do
            {
                Console.Write("Enter Salary ");
            } while (!int.TryParse(Console.ReadLine(), out salary) || salary < 1);

            int day, month, year;
            do
            {
                Console.Write("Enter Hire Day: ");
            } while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31);

            do
            {
                Console.Write("Enter Hire Month: ");
            } while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12);

            do
            {
                Console.Write("Enter Hire Year: ");
            } while (!int.TryParse(Console.ReadLine(), out year) || year > DateTime.Now.Year);

            HireDate hireDate = new HireDate(day, month, year);

            Employee emp4 = new Employee(id, empName, gender, security, salary, hireDate);
            Console.WriteLine(emp4);
            #endregion





        }
    }
}
