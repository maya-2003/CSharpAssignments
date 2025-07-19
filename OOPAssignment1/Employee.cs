using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment1
{
    // Design and implement a Class for the employees in a company
    internal class Employee
    {
        private int id;
        private string name;
        private Security securityLevel;
        private int salary;
        private Gender gender;
        private HireDate hireDate;

        public Employee(int id, string name, Gender gender, Security securityLevel, int salary, HireDate hireDate)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.securityLevel = securityLevel;
            this.salary = salary;
            this.hireDate = hireDate;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Salary { get {  return salary; } set { salary = value; } }
        public Gender Gender { get { return gender; } set { gender = value; } }
        public Security SecurityLevel { get { return securityLevel; } set { securityLevel = value; } }
        public HireDate HireDate { get { return hireDate; } set { hireDate = value; } }

        #region 5-  We want to provide the Employee Class to represent Employee data in a string Form (override ToString ()), display employee salary in a currency format. [ use String.Format Function]
        public override string ToString()
        {
            return $"Employye Data:\n ID: {id}\n Name: {name}\n Gender: {gender}\n Security: {securityLevel}\n Salary: {String.Format("{0:C}", salary)}\n Hire Date: {hireDate.Day}/{hireDate.Month}/{hireDate.Year}";
        }
        #endregion

    }
}
