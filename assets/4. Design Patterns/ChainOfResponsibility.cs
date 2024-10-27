public abstract class Handler
{
    protected Handler _next;

    public void SetNext(Handler next) => _next = next;

    public abstract void HandleRequest(int request);
}

public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
            Console.WriteLine("Handled by Handler1");
        else
            _next?.HandleRequest(request);
    }
}