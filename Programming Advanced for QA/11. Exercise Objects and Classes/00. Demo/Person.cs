using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00._Demo
{
    internal class Person
    {
        private string name;
        private int age;
        private string egn;

        public string Name
        {
            get { return name; }
            set { egn = value; }
        }
        public int Age
        {
            get { return age;}
            set { age = value; }
        }

        public string Egn
        {
            get { return egn; }
            set { egn = value; }
        }
    }
}
