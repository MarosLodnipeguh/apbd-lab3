using apbd_lab3.Exceptions;
using apbd_lab3.Interfaces;

namespace apbd_lab3;

public class CoolingContainer : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; }
    public double SelfWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    
    public String ProductType { get; set; }
    
    public double Temperature { get; set; }
    
    public Dictionary<String, double> PossibleProducts { get; }
    
    public CoolingContainer(double height, double selfWeight, double depth, string serialNumber, double maxLoad, double temperature, Dictionary<String, double> possibleProducts)
    {
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoad = maxLoad;
        Temperature = temperature;
        PossibleProducts = possibleProducts;
        
        FillPossibleProducts();
    }
    
    private void FillPossibleProducts()
    {
        PossibleProducts.Add("Bananas", 13.3);
        PossibleProducts.Add("Chocolate", 18.0);
        PossibleProducts.Add("Fish", 2.0);
        PossibleProducts.Add("Meat", -15.0);
        PossibleProducts.Add("Ice cream", -18.0);
        PossibleProducts.Add("Frozen pizza", -30.0);
        PossibleProducts.Add("Cheese", 7.2);
        PossibleProducts.Add("Sausages", 5);
        PossibleProducts.Add("Butter", 20.5);
        PossibleProducts.Add("Eggs", 19);
    }
    
    
    
    public void Unload()
    {
        CargoWeight = 0;
        ProductType = "";
    }

    public void Load(double cargoWeight)
    {
        if (cargoWeight > MaxLoad)
        {
            throw new OverfillException();
        }
        
        CargoWeight = cargoWeight;
    }

    public void Load(double cargoWeight, String productType)
    {
        if (cargoWeight > MaxLoad)
        {
            throw new OverfillException();
        }

        double minTemperature = PossibleProducts[productType];

        if (Temperature < minTemperature)
        {
            Console.WriteLine("Temperature too low for product: " + productType);
            return;
        }

        
        CargoWeight = cargoWeight;
        ProductType = productType;
    }
 
}