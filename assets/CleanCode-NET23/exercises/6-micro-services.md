# Microservice och SOA Övningar med Lösningar

## Övning 1: Enkel Mikrotjänst
### Instruktioner:
Skapa en enkel mikrotjänst med ASP.NET Core som hanterar produktdata med CRUD-operationer.
- **Syfte**: Lära sig att skapa en grundläggande CRUD-mikrotjänst.
- **Lösning**:
  - Produktmodell med egenskaper för Id, Namn och Pris.
  - ProductsController för att hantera alla CRUD-operationer (Create, Read, Update, Delete).

## Övning 2: Kommunikation Mellan Tjänster
### Instruktioner:
Skapa två tjänster där den ena kan hämta data från den andra via HTTP-kommunikation.
- **Syfte**: Ställa in RESTful kommunikation mellan mikrotjänster.
- **Lösning**:
  - Lägg till en ProductsController som använder HttpClient för att hämta kunddata från en Customer-mikrotjänst.
  - Konfigurera beroendeinjektion för HttpClient.

## Övning 3: API Gateway
### Instruktioner:
Ställ in en API Gateway med hjälp av Ocelot.
- **Syfte**: Centralisera API-routing för klientåtkomst.
- **Lösning**:
  - Ocelot-konfiguration för att dirigera förfrågningar för Products och Customers.

## Övning 4: Tjänsteorienterad Arkitektur
### Instruktioner:
Skapa tjänster som hanterar specifika affärsfunktioner, simulera tjänsteorienterad arkitektur.
- **Syfte**: Förstå designprinciper för tjänsteorientering.
- **Lösning**:
  - Definiera gränssnitt för Order-, Customer- och Payment-tjänster.
  - Simulera ett arbetsflöde genom att anropa varje tjänst i sekvens.

---
