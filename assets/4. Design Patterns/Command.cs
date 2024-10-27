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