using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class ContainerShip
{
    public List<IContainer> Containers { get; set; }
    public double MaxSpeed { get; }
    public int MaxContainersCount { get; }
    public int MaxLoad { get; } // in tons
    
    public ContainerShip(double maxSpeed, int maxContainersCount, int maxLoad)
    {
        Containers = new List<IContainer>();
        MaxSpeed = maxSpeed;
        MaxContainersCount = maxContainersCount;
        MaxLoad = maxLoad;
    }
    
    public void LoadContainer(IContainer container)
    {
        if(Containers.Count >= MaxContainersCount)
        {
            throw new OverfillException();
        }
        
        if(container.CargoWeight > MaxLoad)
        {
            throw new OverfillException();
        }
        
        Containers.Add(container);
    }
    
    public void LoadContainerList (List<IContainer> containers)
    {
        if(Containers.Count + containers.Count > MaxContainersCount)
        {
            throw new OverfillException();
        }
        
        double totalWeight = 0;
        foreach (var container in containers)
        {
            totalWeight += container.CargoWeight;
        }
        
        if(totalWeight > MaxLoad)
        {
            throw new OverfillException();
        }
        
        Containers.AddRange(containers);
    }
    
    public void UnloadContainer(IContainer container)
    {
        Containers.Remove(container);
    }
    
    public void ReplaceContainer(IContainer oldContainer, IContainer newContainer)
    {
        Containers.Remove(oldContainer);
        Containers.Add(newContainer);
    }
    
    public void UnloadAllContainers()
    {
        Containers.Clear();
    }
    
    public void GetContanerInfo(String SerialNumber)
    {
        foreach (var container in Containers)
        {
            if(container.SerialNumber == SerialNumber)
            {
                Console.WriteLine("Container: " + container.SerialNumber);
                Console.WriteLine("Cargo weight: " + container.CargoWeight);
                Console.WriteLine("Height: " + container.Height);
                Console.WriteLine("Self weight: " + container.SelfWeight);
                Console.WriteLine("Depth: " + container.Depth);
                Console.WriteLine("Max load: " + container.MaxLoad);
                Console.WriteLine("Serial number: " + container.SerialNumber);
            }
        }
    }
    
    public void GetShipInfo()
    {
        Console.WriteLine("Max speed: " + MaxSpeed);
        Console.WriteLine("Max containers count: " + MaxContainersCount);
        Console.WriteLine("Max load: " + MaxLoad);
        Console.WriteLine("Current containers count: " + Containers.Count);
        Console.WriteLine("Current load: " + Containers.Sum(c => c.CargoWeight));
    }
    
    
}