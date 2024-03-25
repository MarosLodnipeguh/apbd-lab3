using apbd_lab3;
using Container = apbd_lab3.Container;
using IContainer = apbd_lab3.Interfaces.IContainer;

ContainerShip cs = new ContainerShip(100, 10, 1000);

Container c1 = new Container(10, 10, 10, "KON-C-1", 100);
Container c2 = new Container(10, 10, 10, "KON-C-2", 100);
GasContainer c3 = new GasContainer(10, 10, 10, "KON-G-3", 100, 1000);
LiquidContainer c4 = new LiquidContainer(10, 10, 10, "KON-L-4", 100, true);

cs.LoadContainer(c1);
cs.LoadContainer(c2);
cs.LoadContainer(c3);
cs.LoadContainer(c4);

cs.UnloadContainer(c1);

cs.UnloadAllContainers();

cs.LoadContainerList(new List<IContainer> {c1, c2, c3, c4});

Console.WriteLine("Containers on ship:");

foreach (var container in cs.Containers)
{
    Console.WriteLine(container.SerialNumber);
}









