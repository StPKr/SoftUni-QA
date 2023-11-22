using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car vwMK3 = new Car();
            vwMK3.Make = "VW";
            vwMK3.Model = "MK3";
            vwMK3.Year = 1992;
            vwMK3.FuelQuantity = 200;
            vwMK3.FuelConsumption = 200;
            vwMK3.Drive(2000);
            Console.WriteLine(vwMK3.WhoAmI());
        }
    }
}
