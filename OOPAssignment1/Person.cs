using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment1
{
    internal struct Person
    {
        private int age;
        private string name;

        public Person(int _age, string _name)
        {
            age = _age;
            name = _name;
        }

        public int Age { 
            get { return age; } 
            set { age = value; }
        }
        public string Name { 
            get { return name; } 
            set { name = value; }
        }

        public override string ToString()
        {
            return $"Name: {name} - Age: {age}";

        }
    }
}
