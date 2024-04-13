using System.Diagnostics.Metrics;

namespace _04._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            int badGradesThreshold = int.Parse(Console.ReadLine());
            int gradeCounter = 0;
            int badGradeCounter = 0;
            double averageGrade = 0;
            double sumOfGrades = 0;
            string name = "";
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Enough")
                {
                    break;
                }
                int grade = int.Parse(Console.ReadLine());                
                gradeCounter++;
                name = command;
                if (grade <= 4)
                {
                    badGradeCounter++;
                }
                if (badGradeCounter >= badGradesThreshold)
                {                    
                    break;
                }
                sumOfGrades += grade;
            }
            if (badGradeCounter >= badGradesThreshold)
            {
                Console.WriteLine($"You need a break, {badGradeCounter} poor grades.");
            } else
            {
                averageGrade = (sumOfGrades / gradeCounter);
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {gradeCounter}");
                Console.WriteLine($"Last problem: {name}");
            }
        }
    }
}