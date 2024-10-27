public interface IStrategy
{
    void Execute();
}

public class StrategyA : IStrategy
{
    public void Execute() => Console.WriteLine("Executing strategy A");
}

public class StrategyB : IStrategy
{
    public void Execute() => Console.WriteLine("Executing strategy B");
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy() => _strategy.Execute();
}