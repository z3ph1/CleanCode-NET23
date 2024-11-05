# Övningar – Clean Code, CI/CD, TDD, SOLID, Design Patterns och Microservices

## Övning 1: Clean Code Refaktorisering

**Uppgift**: Ta en bit existerande kod och refaktorera den för att följa clean code-principerna.

1. **Identifiera** delar av koden som är svårförståeliga, innehåller dolda beroenden eller "magic numbers".
2. **Refaktorera** genom att:
   - Byta ut "magic numbers" mot konstanter med beskrivande namn.
   - Dela upp långa metoder och komplexa funktioner i mindre, mer specifika metoder.
3. **Diskutera**: Vad blev lättare att förstå? Hur bidrog refaktoriseringen till kodens underhållbarhet?

---

## Övning 2: Implementera TDD för Enhetstester

**Uppgift**: Använd Test-Driven Development (TDD) för att bygga en enkel funktion.

1. **Planera en funktion** som utför en specifik uppgift, exempelvis en beräkning eller validering.
2. **Skriv enhetstester** för funktionen innan du implementerar den.
3. **Implementera funktionen** och se till att testerna går igenom.
4. **Refaktorera** funktionen om det behövs och säkerställ att testerna fortfarande fungerar.

### Extra:

- Implementera tester för både positiva och negativa fall, inklusive edge-cases.

---

## Övning 3: SOLID i Praktiken

**Uppgift**: Applicera SOLID-principerna på en existerande klass som har flera ansvarsområden.

1. **Single Responsibility Principle (SRP)**: Identifiera och dela upp klassen så att varje klass har ett tydligt, specifikt ansvar.
2. **Open/Closed Principle (OCP)**: Gör klassen öppen för utbyggnad men stängd för ändring.
3. **Dependency Inversion Principle (DIP)**: Använd beroendeinjektion för att minska beroenden och förbättra testbarheten.
4. **Diskutera**: Vilka SOLID-principer var enklast/svårast att applicera, och hur förbättrade de koden?

---

## Övning 4: Design Patterns – Factory och Repository Patterns

**Uppgift**: Implementera två designmönster i ett projekt.

1. **Factory Pattern**: Skapa en Factory-klass som kan generera olika typer av objekt beroende på ett specifikt behov, till exempel för att skapa olika typer av användarroller.
2. **Repository Pattern**: Implementera ett Repository Pattern för att hantera datalagring i en applikation.
3. **Testa**: Skriv enhetstester för dina Factory- och Repository-klasser.

### Extra:

- Implementera Unit of Work för att hantera transaktioner konsekvent i Repository Pattern.

---

## Övning 5: CI/CD Pipeline – Skapa och Konfigurera

**Uppgift**: Skapa en enkel CI/CD-pipeline som automatiserar bygg, test och deployment.

1. **Konfigurera pipeline**: Använd ett CI/CD-verktyg som GitHub Actions, Jenkins eller Azure DevOps.
2. **Automatiska tester**: Lägg till en bygg- och testfas som automatiskt kör tester varje gång ny kod pushas.
3. **Deploy till testmiljö**: Konfigurera pipelinen för att distribuera koden till en testmiljö efter godkända tester.

### Extra:

- Lägg till kodanalysverktyg, till exempel SonarQube, för att upprätthålla kodkvalitet.

---

## Övning 6: Microservices – Dela Upp en Monolit

**Uppgift**: Dela upp en liten monolitisk applikation i flera microservices.

1. **Identifiera tjänster**: Dela upp applikationens olika funktioner i självständiga tjänster (t.ex. användarhantering, produktkatalog, och betalningar).
2. **Skapa REST-API** för varje tjänst och definiera gränssnittet (t.ex. GET, POST, PUT).
3. **Använd Docker för containerisering** av varje tjänst och kör dem med Docker Compose.
4. **Implementera API Gateway** för att hantera externa anrop till microservices.

### Extra:

- Skapa en liten meddelandekö med RabbitMQ för att hantera kommunikation mellan tjänster.

---

## Övning 7: Identifiera och Lös Anti-patterns

**Uppgift**: Gå igenom ett projekt och identifiera minst tre anti-patterns.

1. **Identifiera** vanliga anti-patterns, som Spaghetti Code, God Object, och Magic Numbers.
2. **Refaktorera** koden för att eliminera anti-patterns och ersätta dem med bättre lösningar.
3. **Diskutera**: Vilka anti-patterns är vanligast i teamets arbete, och vad kan göras för att förebygga dem?

### Extra:

- Dokumentera de ändringar som gjorts och förklara hur de förbättrade koden.

---

## Övning 8: Diskutera och Reflektera över Best Practices

**Uppgift**: Reflektera och diskutera de bästa praxis vi gått igenom.

1. **Diskutera i grupp**: Hur kan clean code, TDD, SOLID och CI/CD bidra till hållbar kod?
2. **Identifiera utmaningar**: Vilka utmaningar har teamet mött vid införandet av dessa principer och praxis?
3. **Skapa en handlingsplan**: Skriv ned konkreta åtgärder för att börja följa dessa praxis i pågående och framtida projekt.