# Labb 2 - Microservices (i grupp)

Syftet med denna labb är att bygga en tjänst baserad på microservices-arkitektur, med fokus på best practices som SOLID-principer, design patterns och TDD. Varje gruppmedlem ansvarar för en egen microservice, och tillsammans skapar ni en `API-Gateway eller Swagger` för att möjliggöra kommunikation mellan tjänsterna.

## Gruppstruktur och Arbetsprocess (Grupper om 3-4 personer)

### Labben består av 3 delar

### Del 1: Planering och Arkitektur

1. **Definiera tjänsten**: Som grupp ska ni bestämma er för vilken webbtjänst ni vill bygga. Exempel på tjänster:
   - **Pizzabeställningssystem**: En tjänst lagrar information om pizzor (namn, ingredienser, pris) medan en annan hanterar beställningar.
   - **Användar- och meddelandesystem**: En tjänst lagrar användarprofiler medan en annan lagrar användares meddelanden med metadata.

2. **API-specifikationer**: Skriv API-specifikationer för varje `microservice` och `gateway`:
   - **Endpoints**: Varje tjänst ska stödja minst **GET** och **POST** requests, och kan vid behov även stödja **PUT**, **PATCH** och **DELETE**.

3. **Databas och Repository-struktur**: Bestäm vilken typ av databas (t.ex. SQL, NoSQL) som ska användas. Skapa interfaces, datamodeller och repository-strukturer.

4. **CI/CD**: Sätt upp en CI/CD-pipeline för bygge och publicering av era tjänster på t.ex Docker Registry med hjälp av GitHub Actions/ Azure DevOps eller dyl.

### Del 2: Utveckling av Microservices

Varje medlem i gruppen utvecklar en egen `microservice` enligt följande riktlinjer:

1. **Service och databasuppsättning**:
   - Skapa microservice-projektet med databasmodeller och repository-klasser.
   - Använd **SOLID-principerna** för att skapa löst kopplad och underhållsvänlig kod.
   - Använd design patterns som **Factory**, **Singleton** eller **Observer** där det är relevant för att förbättra struktur och effektivitet.

2. **CI/CD**:
   - Använd CI/CD för att bygga och publicera en Docker image på Docker Registry.

3. **API Gateway eller Swagger**:
   - Implementera en **API Gateway** med [Ocelot](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot) eller använd er av Swagger för att exponera endpoints.
   - Konfigurera routes för varje microservice och implementera loggning av requests.

4. **Containerisering med Docker**:
   - Använd Docker för att containerisera tjänsten och säkerställ enkel deployment.
   - Sätt upp Docker Compose för lokal utveckling av alla tjänster samt API-Gateway.
   - Consumera images i Docker-compose från Docker Registry om möjligt (efter att er CI/CD pipeline publicerat).

### Del 3: Reflektion och Analys

Efter att microservicen är färdig ska varje medlem reflektera kring följande frågor:

1. **Vad har du lärt dig om microservices-arkitektur och dess fördelar och utmaningar?**  
   - Diskutera de specifika fördelarna och svårigheterna du upplevde med att bygga fristående tjänster som kommunicerar genom en gemensam gateway.

2. **Hur har användandet av design patterns och SOLID-principerna påverkat din kodstruktur och systemets underhållbarhet?**  
   - Reflektera över specifika design patterns eller SOLID-principer du har använt. Hur har de bidragit till att förbättra kodens struktur, underhållbarhet och läsbarhet?

3. **Vilka utmaningar och fördelar medförde TDD, och hur har det påverkat kodens kvalitet och utvecklingsprocessen?**  
   - Diskutera hur TDD påverkade ditt sätt att skriva och strukturera kod. Vilka lärdomar har du dragit från att arbeta testdrivet?

4. **Vad skulle du göra annorlunda om du fick genomföra uppgiften igen, och varför?**  
   - Identifiera specifika delar av processen eller tekniker som du skulle förändra eller förbättra. Hur tror du att dessa förändringar skulle påverka projektet som helhet?

5. **Vilka förbättringar skulle du föreslå för den microservices-arkitektur du implementerat?**  
   - Fundera över förbättringsmöjligheter för arkitekturen, till exempel i form av prestandaoptimering, skalbarhet, eller felhantering.

---

## Inlämning och Bedömning

1. Ni ska zippa och ladda upp ert projekt tillsammans med eventuella instruktioner för att bygga och köra tjänsten.
3. Se till att koden är felfri, inga errors i bygget.

### Bedömningskriterier för Godkänt

- Tjänsten har en komplett API-specifikation och stödjer **GET** och **POST** requests.
- Koden följer **SOLID-principerna** och visar på användning av **design patterns**.
- Microservicen är containeriserad och byggs utan problem.
- Reflektionsfrågorna 1 och 2 i Del 3 är besvarade med insiktsfulla reflektioner.

### Bedömningskriterier för Väl Godkänt

- Implementera en **API Gateway** med [Ocelot](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot) istället för Swagger.
- Applikationen ska containeriseras, vilket innebär att alla dess komponenter ska definieras i en docker-compose-fil för uppstart och köras i Docker-containrar under körningstid.
- Reflektionsfrågorna 3, 4 och 5 i Del 3 är besvarade med insiktsfulla reflektioner.

### Utdelning och Deadline

**Utdelning**: 2024-12-02  
**Deadline**: 2024-12-19