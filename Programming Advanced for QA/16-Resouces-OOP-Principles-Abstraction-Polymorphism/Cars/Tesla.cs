using Cars;

internal class Tesla : ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get ; set ; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Break!";
    }

    public override string ToString()
    {
        return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries\n" +
            $"{this.Start()}\n" +
            $"{this.Stop()}";
    }
}