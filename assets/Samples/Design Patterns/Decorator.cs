/*
    Decorator:
    Adds additional functionality to an object dynamically without modifying its structure.
    Example:
    A CarDecorator class enhances the functionality of a BasicCar by adding sports car features.
*/

public interface ICar
{
    void Assemble();
}

public class BasicCar : ICar
{
    public void Assemble() => Console.WriteLine("Assembling a basic car");
}

public class CarDecorator : ICar
{
    protected ICar _car;
    
    public CarDecorator(ICar car)
    {
        _car = car;
    }
    
    public virtual void Assemble() => _car.Assemble();
}

public class SportsCar : CarDecorator
{
    public SportsCar(ICar car) : base(car) {}
    
    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding features of a sports car.");
    }
}