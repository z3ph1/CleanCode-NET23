/*
    Command:
    Encapsulates a request as an object, allowing parameterization of clients with different requests.
    Example:
    A TurnOnCommand encapsulates the action of turning on a Light object.
*/

public interface ICommand
{
    void Execute();
}

public class Light
{
    public void TurnOn() => Console.WriteLine("Light is ON");
}

public class TurnOnCommand : ICommand
{
    private Light _light;
    
    public TurnOnCommand(Light light)
    {
        _light = light;
    }
    
    public void Execute() => _light.TurnOn();
}