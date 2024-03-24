namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var container1 = new FluidContainer(10, 20, 10, 100);
        container1.LoadContainer(40, true, "metanol");
        var container2 = new GasContainer(8, 15, 12, 50, 0);
        container2.LoadContainer(30);
        var container3 = new FreezeContainer(8, 15, 12, 50, "banany", 13.3, 15);
        container3.LoadContainer(45, "banany");
        container3.PrintInfo();
        
        var containers = new List<Container>();
        containers.Add(container2);
        containers.Add(container3);
        
        var containerShip = new ContainerShip(10, 100, 30000);
        containerShip.LoadContainer(container1);
        containerShip.LoadContainers(containers);
        containerShip.UnloadContainer(container3);
        container3.EmptyContainer();
        containerShip.ReplaceContainer(container2, container3);
        var containerShip2 = new ContainerShip(15, 50, 15000);
        containerShip.MoveContainer(containerShip2, container3);
        containerShip.PrintInfo();
        
    }
}