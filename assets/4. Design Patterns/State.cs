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