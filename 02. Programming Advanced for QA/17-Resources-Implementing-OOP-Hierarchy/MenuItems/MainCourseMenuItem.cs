using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOopHierarchy.MenuItems
{
    public class MainCourseMenuItem : MenuItem
    {
        public MainCourseMenuItem(string name, string description, decimal price)
            : base(name, description, price)
        {
        }

        public override string ToString()
        {
            return $"Main Course: {base.ToString()}";
        }
    }
}
