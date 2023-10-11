using System;

namespace _08_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double examHour = double.Parse(Console.ReadLine());
            double examMin = double.Parse(Console.ReadLine());
            double arrivalHour = double.Parse(Console.ReadLine());
            double arrivalMin = double.Parse(Console.ReadLine());
            double totExam = examHour * 60 + examMin;
            double totArrival = arrivalHour * 60 + arrivalMin;
            double remainMinutes;
            double remainHour;
            if (totExam - totArrival > 30)
            {
                Console.WriteLine("Early");
                remainHour = Math.Floor((totExam - totArrival) / 60);
                remainMinutes = totExam - totArrival - (remainHour * 60);
                if (remainHour <= 0)
                {
                    Console.WriteLine($"{remainMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{remainHour}:{remainMinutes:00} hours before the start");
                }
            }
            else if (totExam - totArrival >= 0)
            {
                Console.WriteLine("On time");
                remainHour = Math.Floor((totExam - totArrival) / 60);
                remainMinutes = totExam - totArrival - (remainHour * 60);
                if (totArrival != totExam)
                {
                    Console.WriteLine($"{remainMinutes} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Late");
                remainHour = Math.Floor((totArrival - totExam) / 60);
                remainMinutes = totArrival - totExam - (remainHour * 60);
                if (remainHour <= 0)
                {
                    Console.WriteLine($"{remainMinutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{remainHour}:{remainMinutes:00} hours after the start");
                }
            }
        }
    }
}