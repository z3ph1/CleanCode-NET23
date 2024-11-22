
# Lösningsförslag Design Patterns in C#

### Lösningsförslag: Singleton Pattern
```csharp
using System;
using System.IO;

public sealed class Logger
{
    private static readonly object lockObject = new object();
    private static Logger instance;

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
    }

    public void Log(string message)
    {
        string logFilePath = "log.txt";
        File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger.Instance.Log("Application started.");
        Logger.Instance.Log("Another log entry.");
    }
}
```

---

### Lösningsförslag: Strategy Pattern
```csharp
using System;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Betalar {amount} med kreditkort.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Betalar {amount} via PayPal.");
    }
}

public class PaymentContext
{
    private readonly IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välj betalningsmetod (1: Kreditkort, 2: PayPal):");
        int choice = int.Parse(Console.ReadLine());

        IPaymentStrategy paymentStrategy = choice switch
        {
            1 => new CreditCardPayment(),
            2 => new PayPalPayment(),
            _ => throw new ArgumentException("Ogiltigt val")
        };

        PaymentContext context = new PaymentContext(paymentStrategy);
        context.ProcessPayment(500);
    }
}
```

---

### Lösningsförslag: Factory Pattern
```csharp
using System;

public interface IVehicle
{
    void Drive();
}

public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Kör en bil.");
    }
}

public class Motorcycle : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Kör en motorcykel.");
    }
}

public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Kör en lastbil.");
    }
}

public enum VehicleType
{
    Car,
    Motorcycle,
    Truck
}

public static IVehicle CreateVehicle(VehicleType type)
{
    IVehicle vehicle;

    switch (type)
    {
        case VehicleType.Car:
            vehicle = new Car();
            break;
        case VehicleType.Motorcycle:
            vehicle = new Motorcycle();
            break;
        case VehicleType.Truck:
            vehicle = new Truck();
            break;
        default:
            throw new ArgumentException("Ogiltig fordontyp");
    }

    return vehicle;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Välj fordonstyp (car, motorcycle, truck):");
        string choice = Console.ReadLine();

        IVehicle vehicle = VehicleFactory.CreateVehicle(choice);
        vehicle.Drive();
    }
}
```
