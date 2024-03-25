namespace apbd_lab3.Interfaces;

public interface IContainer
{
    public double CargoWeight { set; get; }
    public double Height { get; }
    public double SelfWeight { get; }
    public double Depth { get; }
    public String SerialNumber { get; }
    public double MaxLoad { get; }
    
    public void Unload();
    public void Load(double cargoWeight);
}