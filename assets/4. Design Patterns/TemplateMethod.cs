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