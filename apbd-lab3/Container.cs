using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class Container : IContainer
{
    // private double _cargoWeight;

    public double CargoWeight { get; set; }
    public double Height { get; set; }

    public Container(double cargoWeight, double height)
    {
        CargoWeight = cargoWeight;
        Height = height;
    }

    public void Unload()
    {
        throw new OverfillException();
    }
    
    public void Load(double cargoWeight)
    {
        throw new NotImplementedException();
    }
    

    // public double getCargoWeight()
    // {
    //     return _cargoWeight;
    // }
    //
    // public void setCargoWeight(double value)
    // {
    //     _cargoWeight = value;
    // }

}