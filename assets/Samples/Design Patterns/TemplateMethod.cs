/*
    Template Method:
    Defines the skeleton of an algorithm, with steps that can be overridden by subclasses.
    Example:
    A Game class defines the structure of playing a game, with specific games (like Football) providing details.
*/

public abstract class Game
{
    public void Play()
    {
        Initialize();
        Start();
        End();
    }

    protected abstract void Initialize();
    protected abstract void Start();
    protected abstract void End();
}

public class Football : Game
{
    protected override void Initialize() => Console.WriteLine("Football initialized");
    protected override void Start() => Console.WriteLine("Football started");
    protected override void End() => Console.WriteLine("Football ended");
}