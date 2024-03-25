using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; }
    public double SelfWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    
    public Container(double height, double selfWeight, double depth, string serialNumber, double maxLoad)
    {
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoad = maxLoad;
    }
    
    public void Unload()
    {
        CargoWeight = 0;
    }

    public void Load(double cargoWeight)
    {
        if (cargoWeight > MaxLoad)
        {
            throw new OverfillException();
        }
        
        CargoWeight = cargoWeight;
    }
}