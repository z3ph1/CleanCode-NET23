/*
    State:
    Allows an object to change its behavior when its internal state changes.
    Example:
    A Context object changes its behavior based on the current state (ConcreteStateA, ConcreteStateB).
*/

public interface IState
{
    void Handle(Context context);
}

public class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State A handling");
        context.State = new ConcreteStateB();
    }
}

public class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State B handling");
        context.State = new ConcreteStateA();
    }
}

public class Context
{
    public IState State { get; set; }
    
    public Context(IState state)
    {
        State = state;
    }

    public void Request() => State.Handle(this);
}