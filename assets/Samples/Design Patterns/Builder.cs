/*
    Builder:
    Separates the construction of an object from its representation, allowing step-by-step object creation.
    Example:
    A CarBuilder class constructs a Car object by setting various properties like Engine and Wheels.
*/

public class Car
{
    public string Engine { get; set; }
    public int Wheels { get; set; }
}

public class CarBuilder
{
    private Car _car = new Car();
    
    public CarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public CarBuilder SetWheels(int wheels)
    {
        _car.Wheels = wheels;
        return this;
    }

    public Car Build() => _car;
}