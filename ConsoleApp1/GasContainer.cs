namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    
    public GasContainer(int height, int weight, int depth, double maxCargoWeight, double pressure) : base(height, weight, depth, maxCargoWeight)
    {
        SerialString = "KON-G-" + CurrentSerialNumber;
        CurrentSerialNumber++;
        Pressure = pressure;
    }
    public void NotifyDangerousSituation()
    {
        Console.WriteLine(SerialString);
    }
    public override void EmptyContainer()
    {
        CargoWeight *= 0.05;
    }
    public void LoadContainer(double loadWeight)
    {
        base.LoadContainer(loadWeight);
    }
    public override void PrintInfo()
    {
        Console.WriteLine("Kontener na gaz");
        base.PrintInfo();
        Console.WriteLine("Ciśnienie (w atmosferach): " + Pressure);
    }
}