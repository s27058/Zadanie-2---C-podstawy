namespace ConsoleApp1;

public class Container
{
    protected static int CurrentSerialNumber = 1;
    public double CargoWeight { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public int Depth { get; set; }
    public string SerialString { get; set; }
    public double MaxCargoWeight { get; set; }
    

    protected Container(int height, int weight, int depth, double maxCargoWeight)
    {
        CargoWeight = 0;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxCargoWeight = maxCargoWeight;
    }

    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
    }

    protected void LoadContainer(double loadWeight)
    {
        if (CargoWeight + loadWeight > MaxCargoWeight)
        {
            throw new OverfillException();
        }
        CargoWeight += loadWeight;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine("Numer seryjny: "+ SerialString);
        Console.WriteLine("Waga ładunku (w kilogramach): "+ CargoWeight);
        Console.WriteLine("Wysokość (w centymetrach): "+ Height);
        Console.WriteLine("Głębokość (w centymetrach): "+ Depth);
        Console.WriteLine("Maksymalna ładowność danego kontenera (w kilogramach): "+ MaxCargoWeight);
    }
    
}