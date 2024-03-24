namespace ConsoleApp1;

public class FluidContainer : Container, IHazardNotifier
{
    public bool IsFluidDangerous { get; set; }
    public string? FluidName { get; set; }
    public FluidContainer(int height, int weight, int depth, double maxCargoWeight) : base(height, weight, depth, maxCargoWeight)
    {
        SerialString = "KON-L-" + CurrentSerialNumber;
        CurrentSerialNumber++;
    }

    public void NotifyDangerousSituation()
    {
        Console.WriteLine($"W kontenerze o numerze seryjnym: {SerialString}, zaszła niebezpieczna sytuacja.");
    }

    public override void EmptyContainer()
    {
        base.EmptyContainer();
        FluidName = null;
    }
    
    public void LoadContainer(double loadWeight, bool isFluidDangerous, string fluidName)
    {
        if (isFluidDangerous)
        {
            if (CargoWeight + loadWeight > MaxCargoWeight*0.5)
            {
                NotifyDangerousSituation();
                return;
            }
        }
        else
        {
            if (CargoWeight + loadWeight > MaxCargoWeight*0.9)
            {
                NotifyDangerousSituation();
                return;
            }
        }

        FluidName = fluidName;
        IsFluidDangerous = isFluidDangerous;
        CargoWeight += loadWeight;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Kontener na płyny");
        base.PrintInfo();
        if (FluidName != null)
        {
            Console.WriteLine("Nazwa przewożonego płynu: " + FluidName);
            Console.WriteLine("Czy przewożony płyn jest niebezpieczny: " + IsFluidDangerous);
        }
        else
        {
            Console.WriteLine("Kontener jest pusty");
        }
        
    }
}