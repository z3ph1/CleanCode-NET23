var builder = WebApplication.CreateBuilder(args);

// Lägg till följande om det inte redan finns
builder.Configuration.AddEnvironmentVariables();

// Använd anslutningssträngen
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Konfigurera databaskontexten
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));

// Resten av din kod...
