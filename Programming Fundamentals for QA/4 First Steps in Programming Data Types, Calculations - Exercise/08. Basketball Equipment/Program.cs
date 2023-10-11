namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());
            double kec = tax - tax * 0.4;
            double ekip = kec - kec * 0.2;
            double top = ekip * 0.25;
            double aks = top * 0.2;
            double sum = tax + kec + ekip + top + aks;
            Console.WriteLine(sum);
        }
    }
}