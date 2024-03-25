using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class GasContainer : IContainer, IHazardNotifier
{
    public double CargoWeight { get; set; }
    public double Height { get; }
    public double SelfWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    
    private double Pressure { get; }
    
    public GasContainer(double height, double selfWeight, double depth, string serialNumber, double maxLoad, double pressure)
    {
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoad = maxLoad;
        Pressure = pressure;
    }
    
    
    
    public void Unload()
    {
        CargoWeight = CargoWeight*0.05;
    }

    public void Load(double cargoWeight)
    {
        if(CargoWeight > MaxLoad)
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