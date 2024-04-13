using System;

namespace _10._Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int i = 1;
            
            int badGradeCount = 0;
            bool hasExcluded = false;
            double sumOfGrades = 0;
            while (i <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                   
                        Console.WriteLine($"{name} has been excluded at {i} grade");
                        hasExcluded = true;
                        break;
                    }
                 
                sumOfGrades += grade;
                i++;                
            }
            if (!hasExcluded)
            {
                double avgGrade = sumOfGrades / 12;
                Console.WriteLine($"{name} graduated. Average grade: {avgGrade:f2}");
            }
           
        }
    }
}