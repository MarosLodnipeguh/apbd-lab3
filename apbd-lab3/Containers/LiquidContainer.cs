using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class LiquidContainer : IContainer, IHazardNotifier
{
    public double CargoWeight { get; set; }
    public double Height { get; }
    public double SelfWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    
    private bool IsHazardous { get; }
    
    public LiquidContainer(double height, double selfWeight, double depth, string serialNumber, double maxLoad, bool isHazardous)
    {
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoad = maxLoad;
        IsHazardous = isHazardous;
    }
    
    public void Unload()
    {
        CargoWeight = 0;
    }

    public void Load(double cargoWeight)
    {
        if (IsHazardous)
        {
            if (cargoWeight > MaxLoad*0.5)
            {
                NotifyHazard();
            }
        }
        else
        {
            if (cargoWeight > MaxLoad*0.9)
            {
                NotifyHazard();
            }
        }

        if (cargoWeight > MaxLoad)
        {
            throw new OverfillException();
        }
        
        CargoWeight = cargoWeight;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("Hazardous cargo loaded into container: " + SerialNumber);
    }
}