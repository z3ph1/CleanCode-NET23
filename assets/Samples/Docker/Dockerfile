# Byggfasen
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopiera projektfilen och återställ beroenden
COPY *.csproj ./
RUN dotnet restore

# Kopiera all källkod och bygg applikationen
COPY . ./
RUN dotnet publish -c Release -o out

# Körfasen
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponera port 80
EXPOSE 80

# Sätt miljövariabler för databasanslutning (om det behövs)
# ENV ConnectionStrings__DefaultConnection="Server=db;Database=mydb;User Id=postgres;Password=postgres;"

# Starta applikationen
ENTRYPOINT ["dotnet", "WebbApplikation.dll"]
