namespace _04._Train_the_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            double localGrade = 0;
            double globalGrade = 0;
            int counter = 0;
            while (true)
            {
                string presentationNmae = Console.ReadLine();

                if (presentationNmae == "Finish")
                {
                    break;
                }
                for (int i = 1; i <= jury; i++)
                {
                    double presentationGrade = double.Parse(Console.ReadLine());
                    localGrade += presentationGrade;
                    counter++;
                }
                Console.WriteLine(presentationNmae + " - " + Math.Round(localGrade / jury,2).ToString("0.00") + ".");
                globalGrade += localGrade;
                localGrade = 0;


            }

            Console.WriteLine("Student's final assessment is " + Math.Round(globalGrade/counter,2).ToString("0.00") + ".");
        }
    }
}