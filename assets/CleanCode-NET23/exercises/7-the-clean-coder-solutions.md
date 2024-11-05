# Lösningsförslag – Clean Code, CI/CD, TDD, SOLID, Design Patterns och Microservices

## Lösning 1: Clean Code Refaktorisering

**Lösning:**

### Steg 1: Identifiera problem

Leta efter kod som är svår att förstå, såsom "magic numbers", långa metoder eller otydliga variabelnamn.

**Exempel på ursprunglig kod:**

```csharp
public class Calculator
{
    public int Calculate(int a, int b, int operation)
    {
        if (operation == 1)
        {
            return a + b;
        }
        else if (operation == 2)
        {
            return a - b;
        }
        else if (operation == 3)
        {
            return a * b;
        }
        else
        {
            return 0;
        }
    }
}
```

### Steg 2: Byt ut "magic numbers"
#### Definiera en enum för operationerna:

```csharp
public enum Operation
{
    Add = 1,
    Subtract = 2,
    Multiply = 3
}
```

#### Använd enumen i koden:

```csharp
public int Calculate(int a, int b, Operation operation)
{
    if (operation == Operation.Add)
    {
        return a + b;
    }
    else if (operation == Operation.Subtract)
    {
        return a - b;
    }
    else if (operation == Operation.Multiply)
    {
        return a * b;
    }
    else
    {
        return 0;
    }
}
```

### Steg 3: Dela upp långa metoder

#### Bryt ner metoden i mindre, mer specifika metoder:

```csharp
public int Calculate(int a, int b, Operation operation)
{
    switch (operation)
    {
        case Operation.Add:
            return Add(a, b);
        case Operation.Subtract:
            return Subtract(a, b);
        case Operation.Multiply:
            return Multiply(a, b);
        default:
            throw new InvalidOperationException("Ogiltig operation");
    }
}

private int Add(int a, int b)
{
    return a + b;
}

private int Subtract(int a, int b)
{
    return a - b;
}

private int Multiply(int a, int b)
{
    return a * b;
}
```

# Lösning 2: Implementera TDD för Enhetstester

**Lösning:**

### Steg 1: Skriv enhetstest först

#### Skapa ett test för en funktion som ska kontrollera om ett tal är jämnt.

```csharp
[Fact]
public void IsEven_GivenEvenNumber_ReturnsTrue()
{
    var mathHelper = new MathHelper();
    bool result = mathHelper.IsEven(4);
    Assert.True(result);
}

[Fact]
public void IsEven_GivenOddNumber_ReturnsFalse()
{
    var mathHelper = new MathHelper();
    bool result = mathHelper.IsEven(5);
    Assert.False(result);
}
```

### Steg 2: Implementera funktionen

#### Implementera metoden så att testerna går igenom

```csharp
public class MathHelper
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
```

### Steg 3: Refaktorera vid behov

#### Om du behöver förbättra koden ytterligare, gör det och säkerställ att testerna fortfarande passerar

# Lösning 3: SOLID i Praktiken

### Steg 1: Single Responsibility Principle (SRP)

#### Ursprunglig klass med flera ansvarsområden:

```csharp
public class ReportGenerator
{
    public void GenerateReport()
    {
        // Hämta data
        // Generera rapport
        // Skicka rapport via e-post
    }
}
```

#### Refaktorerad kod:

```csharp
public class DataFetcher
{
    public Data GetData()
    {
        // Hämta data
    }
}

public class ReportCreator
{
    public Report GenerateReport(Data data)
    {
        // Generera rapport
    }
}

public class EmailSender
{
    public void SendEmail(Report report)
    {
        // Skicka rapport via e-post
    }
}
```

### Steg 2: Open/Closed Principle (OCP)

#### Använd interfaces för att göra klasserna öppna för utbyggnad men stängda för ändring.'

```csharp
public interface IReportFormatter
{
    string FormatReport(Report report);
}

public class PdfReportFormatter : IReportFormatter
{
    public string FormatReport(Report report)
    {
        // Format som PDF
    }
}

public class HtmlReportFormatter : IReportFormatter
{
    public string FormatReport(Report report)
    {
        // Format som HTML
    }
}
```

### Steg 3: Dependency Inversion Principle (DIP)

```csharp
public class ReportService
{
    private readonly IReportFormatter _formatter;

    public ReportService(IReportFormatter formatter)
    {
        _formatter = formatter;
    }

    public void CreateAndSendReport()
    {
        var data = new DataFetcher().GetData();
        var report = new ReportCreator().GenerateReport(data);
        var formattedReport = _formatter.FormatReport(report);
        new EmailSender().SendEmail(formattedReport);
    }
}
```

# Lösning 4: Design Patterns – Factory och Repository Patterns

### Factory Pattern

#### Skapa en fabriksklass för att skapa olika objekt.

```csharp
public abstract class Notification
{
    public abstract void Send(string message);
}

public class EmailNotification : Notification
{
    public override void Send(string message)
    {
        // Skicka e-post
    }
}

public class SmsNotification : Notification
{
    public override void Send(string message)
    {
        // Skicka SMS
    }
}

public class NotificationFactory
{
    public static Notification CreateNotification(string channel)
    {
        switch (channel)
        {
            case "Email":
                return new EmailNotification();
            case "SMS":
                return new SmsNotification();
            default:
                throw new Exception("Ogiltig kanal");
        }
    }
}
```

### Repository Pattern

#### Implementera ett repository för datalagring

```csharp
public interface IProductRepository
{
    Product GetById(int id);
    IEnumerable<Product> GetAll();
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}

public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public Product GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
    }
}
```

### Unit of Work

```csharp
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    int Complete();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    public IProductRepository Products { get; private set; }

    public UnitOfWork(DbContext context)
    {
        _context = context;
        Products = new ProductRepository(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
```

# Lösning 5: CI/CD Pipeline – Skapa och Konfigurera

### Steg 1: Konfigurera pipeline

#### Använd GitHub Actions och skapa filen
***.github/workflows/dotnet.yml:***

```yaml
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3

    - name: Setup .NET
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: 6.0.x

    - name: Restore dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --no-restore

    - name: Test
      run: dotnet test --no-build --verbosity normal
```

### Steg 2: Automatiska tester

#### Tester körs automatiskt vid varje push eller pull request enligt konfigurationen ovan.

### Steg 3: Deploy till testmiljö

#### Lägg till steg för deployment, exempelvis:

```yaml
    - name: Deploy to Azure Web App
      uses: azure/webapps-deploy@v2
      with:
        app-name: your-app-name
        slot-name: staging
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
        package: ./path/to/your/package
```

# Lösning 6: Microservices – Dela Upp en Monolit

### Steg 1: Identifiera tjänster

#### Dela upp applikationen i separata tjänster:

1. UserService
2. ProductService
3. OrderService

### Steg 2: Skapa REST-API för varje tjänst

#### Exempel för UserService:

```csharp
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        // Hämta användare
    }

    [HttpPost]
    public ActionResult CreateUser(User user)
    {
        // Skapa användare
    }
}
```

### Steg 3: Använd Docker för containerisering

#### Skapa en ***Dockerfile*** för varje tjänst.

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./app /app
WORKDIR /app
ENTRYPOINT ["dotnet", "UserService.dll"]
```
### Steg 4: Använd Docker Compose

#### Skapa en ***docker-compose.yml*** fil:.

```yaml
version: '3.8'
services:
  userservice:
    build:
      context: ./UserService
    ports:
      - "5001:80"
  productservice:
    build:
      context: ./ProductService
    ports:
      - "5002:80"
  orderservice:
    build:
      context: ./OrderService
    ports:
      - "5003:80"
```

### Steg 5: Implementera API Gateway

#### Använd Ocelot för API Gateway.

##### Konfiguration i ocelot.json:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/users/{id}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        {
          "Host": "userservice",
          "Port": 80
        }
      ],
      "UpstreamPathTemplate": "/users/{id}",
      "UpstreamHttpMethod": [ "GET" ]
    }
    // Lägg till fler routes för andra tjänster
  ],
  "GlobalConfiguration": {
    "BaseUrl": "http://localhost:5000"
  }
}
```

# Lösning 7: Identifiera och Lös Anti-patterns

### Steg 1: Identifiera anti-patterns

Exempel på anti-patterns i koden:

1. Spaghetti Code: Oorganiserad kod med dålig struktur.
2. God Object: En klass som gör för mycket.
3. Magic Numbers: Oklara numeriska värden utan förklaring.

### Steg 2: Refaktorera koden

Spaghetti Code:

1. Inför tydlig kodstruktur.
2. Dela upp koden i moduler och klasser med specifika ansvar.

God Object:

1. Dela upp stora klasser i mindre, mer fokuserade klasser.

Magic Numbers:

1. Ersätt med konstanter eller enums.

```csharp
// Från
if (user.RoleId == 1)
{
    // Administratör
}

// Till
public enum UserRole
{
    Admin = 1,
    Member = 2,
    Guest = 3
}

if (user.RoleId == (int)UserRole.Admin)
{
    // Administratör
}
```

### Steg 3: Diskutera och dokumentera

#### Dokumentera vilka anti-patterns som identifierades och hur de åtgärdades.

# Lösning 8: Diskutera och Reflektera över Best Practices

### Steg 1: Diskutera i grupp

1. Hur clean code förbättrar läsbarhet och underhållbarhet.
2. TDD roll i att säkerställa kodkvalitet.
3. Hur SOLID-principerna bidrar till en flexibel arkitektur.
4. Fördelarna med CI/CD i utvecklingsprocessen.

### Steg 2: Identifiera utmaningar

1. Motstånd mot förändring i arbetsvanor.
2. Brist på tid för att implementera tester.
3. Kunskapsluckor inom teamet.

### Steg 3: Skapa en handlingsplan

1. Anordna workshops för att utbilda teamet.
2. Införa kodgranskningar för att upprätthålla kodstandarder.
3. Prioritera tid för att skriva tester och refaktorera kod.