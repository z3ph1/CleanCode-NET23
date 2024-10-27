/*
   Abstract Factory:
   Creates families of related objects without specifying their concrete classes.
   Example:
   A CarFactory can create a SportsCar or a Truck, both implementing the ICar interface.
*/

public interface ICar
{
    void Drive();
}

public class SportsCar : ICar
{
    public void Drive() => Console.WriteLine("Driving a sports car!");
}

public class Truck : ICar
{
    public void Drive() => Console.WriteLine("Driving a truck!");
}

public interface ICarFactory
{
    ICar CreateCar();
}

public class SportsCarFactory : ICarFactory
{
    public ICar CreateCar() => new SportsCar();
}

public class TruckFactory : ICarFactory
{
    public ICar CreateCar() => new Truck();
}