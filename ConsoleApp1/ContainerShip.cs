namespace ConsoleApp1;

public class ContainerShip(int maxSpeed, int maxNumberOfContainers, double maxWeightOfContainers)
{
    private List<Container> Containers { get; set; } = new List<Container>(maxNumberOfContainers);
    public int MaxSpeed { get; set; } = maxSpeed;
    private int MaxNumberOfContainers { get; set; } = maxNumberOfContainers;
    private double MaxWeightOfContainers { get; set; } = maxWeightOfContainers;
    private double CurrentWeightOfContainers { get; set; }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxNumberOfContainers)
        {
            throw new Exception("Nie można dodać kontenera, bo zostanie przekroczony limit liczby kontenerów.");
        }
        if (CurrentWeightOfContainers + container.CargoWeight + container.Weight > MaxWeightOfContainers)
        {
            throw new Exception("Nie można dodać kontenera, bo zostanie przekroczony limit wagi na statku.");
        }
        Containers.Add(container);
        CurrentWeightOfContainers += container.CargoWeight + container.Weight;
    }
    
    public void LoadContainers(List<Container> containers)
    {
        double sumOfWeights = 0;
        containers.ForEach(delegate(Container container)
        {
            sumOfWeights += container.Weight + container.CargoWeight;
        });
        if (Containers.Count + containers.Count > MaxNumberOfContainers)
        {
            throw new Exception("Nie można dodać kontenerów, bo zostanie przekroczony limit liczby kontenerów.");
        }
        if (CurrentWeightOfContainers + sumOfWeights > MaxWeightOfContainers)
        {
            throw new Exception("Nie można dodać kontenerów, bo zostanie przekroczony limit wagi na statku.");
        }
        Containers.AddRange(containers);
        CurrentWeightOfContainers += sumOfWeights;
    }
    
    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
        CurrentWeightOfContainers -= container.CargoWeight + container.Weight;
    }
    
    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        UnloadContainer(oldContainer);
        LoadContainer(newContainer);
    }

    public void MoveContainer(ContainerShip newShip, Container container)
    {
        UnloadContainer(container);
        newShip.LoadContainer(container);
    }

    public void PrintInfo()
    {
        Console.WriteLine("Kontenerowiec");
        Console.WriteLine("Maksymalna prędkość (w węzłach): "+MaxSpeed);
        Console.WriteLine("Maksymalna liczba kontenerów: "+MaxNumberOfContainers);
        Console.WriteLine("Maksymalna waga wszystkich kontenerów (w tonach): "+MaxWeightOfContainers);
        Console.WriteLine();
        Console.WriteLine("Informacje o przewożonych kontenerach: ");
        Containers.ForEach(delegate(Container container)
            {
                container.PrintInfo();
                Console.WriteLine();
            });
    }
    
}