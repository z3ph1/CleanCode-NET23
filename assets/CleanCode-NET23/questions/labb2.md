# Frågor om microservices

## 1. Behöver varje service ha en egen databas?

**Svar:**  
Det beror på arkitekturen och kraven, men i en strikt mikrotjänstarkitektur är det rekommenderat att varje service har en egen databas. Detta kallas **Database per Service** och syftar till att minimera kopplingar mellan tjänster och göra dem självständiga.

### Fördelar med separat databas:
- **Självständighet**: Varje service kan utvecklas, distribueras och skalas oberoende.
- **Teknisk frihet**: Varje service kan välja den databas som bäst passar dess behov (t.ex. relationell eller NoSQL).
- **Felisolering**: Om en tjänsts databas går ner påverkas inte andra tjänster.

### Nackdelar:
- **Dataintegritet**: Svårare att upprätthålla transaktioner som spänner över flera databaser.
- **Komplexitet**: Kräver mer hantering vid dataintegration och övervakning.

### Alternativ:
I vissa fall kan tjänster dela en databas (t.ex. i tidiga stadier av projektet), men det kan skapa starkare kopplingar mellan tjänster och minska flexibiliteten.

---

## 2. Kan en service hämta data från valfri databas?

**Svar:**  
I en strikt mikrotjänstarkitektur är detta inte rekommenderat. En tjänst ska **inte** direkt hämta data från en annan tjänsts databas, eftersom detta bryter mot principerna om **löskoppling** och **ägarskap**.

### Rätt sätt att hämta data:
- Om en tjänst (t.ex. SearchService) behöver data från en annan tjänsts databas, bör den kommunicera via **API:er** eller meddelanden.
- Detta garanterar att varje tjänst kontrollerar åtkomsten till sin egen data och att andra tjänster endast kan hämta data via definierade kontrakt.

### Undantag:
- Vid batchjobb eller analys där många tjänsters data behövs kan en separat **data lake** eller **central databas** användas för rapportering och sökning.

---

## 3. Om produkter har kategorier, ska kategorier då ha egen service?

**Svar:**  
Det beror på systemets krav och komplexitet. Här är riktlinjer:

### **Egen service för kategorier:**
- Om kategorier har komplex affärslogik, många relationer eller hanteras av separata team, kan de placeras i en egen service (t.ex. **CategoryService**).
- **Exempel**: Om kategorier används av både **ProductService** och **SearchService**, kan det vara praktiskt att abstrahera dem i en egen service.

### **Del av ProductService:**
- Om kategorier bara är kopplade till produkter och inte används av andra tjänster, kan de hanteras inom **ProductService**.
- **Exempel**: En enkel produktkatalog där kategorier endast används för att gruppera produkter.

### **Rekommendation:**
Analysera beroenden och logik. Om kategorier används i flera domäner, bör de placeras i en egen service.

---

## 4. Ska varje Controller/Publisher ha eget repo? Varje Service/Subscriber eget?

**Svar:**  
Hur koden delas upp i repositories beror på teamets arbetsflöde och tjänsternas koppling. Här är rekommendationer:

### Enkel lösning:
- **Ett repo per tjänst**: Varje mikrotjänst får ett eget repo som inkluderar dess Controllers, Services, databaskod, etc.
  - **Fördelar**: Klart och tydligt; varje repo är självständigt och innehåller allt för en tjänst.
  - **Nackdelar**: Kan leda till många repositories i stora projekt.

### Modulär lösning:
- **Delade moduler**: Vanliga komponenter (t.ex. gemensamma bibliotek för loggning, autentisering) placeras i ett separat repo som används av flera tjänster.
- **Exempel**:
  - **API Gateway** kan ha sitt eget repo.
  - **Controller och Publisher** kan vara i samma repo om de tillhör samma tjänst.

### Rekommendation:
För att effektivisera bygg- och distributionsprocessen för mikrotjänster bör varje mikrotjänst ha sitt **eget repository**. Detta beror på att ni kommer att skapa Docker-images för varje mikrotjänst och publicera dessa till ett **Docker Container Registry** (t.ex. Azure Container Registry, AWS ECR eller **Docker Hub**). 
Denna struktur förenklar CI/CD-processen och minskar komplexiteten.

---

## 5. Vart hamnar databasen?

**Svar:**  
Databasen för varje tjänst hanteras separat, ofta på följande sätt:
- **I tjänstens repo**: Skapande och hantering av databasscheman (t.ex. migrationsfiler) placeras i tjänstens repo.
- **Molnbaserad databas**: Databasen kan ligga på molnplattformar som AWS RDS, Azure SQL, eller MongoDB Atlas.

---

## 6. Ska API Gateway ha eget repo?

**Svar:**  
Ja, API Gateway bör ha ett eget repo. Det är en central del av systemet och används för att:
- **Hantera inkommande anrop**.
- **Routing till rätt tjänster**.
- **Säkerhet** (t.ex. autentisering och ratelimiting).

Genom att placera API Gateway i ett eget repo kan det hanteras och distribueras självständigt.

---

## **Sammanfattning:**
1. **Egen databas för varje tjänst** är idealiskt, men kan undvikas i små projekt.
2. Tjänster ska **inte direkt läsa andra tjänsters databaser**; använd **API:er** eller meddelanden (RabbitMQ).
3. **Kategorier** kan vara en del av **ProductService** eller en egen service beroende på beroenden och logik.
4. **Ett repo per tjänst** är standard i mikrotjänstarkitektur, men delade moduler kan ha egna repo.
5. **API Gateway bör ha ett eget repo.**

---

## **Varför separata repositories?**

### **Individuell hantering av CI/CD pipelines**:
- Om alla mikrotjänster finns i samma repo, måste CI/CD-pipelines ta hänsyn till alla tjänster och avgöra vilken som behöver byggas och distribueras.
- Detta leder till **komplexa pipelines** som kräver extra logik för att identifiera ändringar, vilket ökar underhållskostnaden.

### **Snabbare utvecklingscykel**:
- Med separata repositories kan varje mikrotjänst ha sin egen CI/CD-pipeline, vilket gör det enklare att hantera kodändringar och snabbare bygga och publicera en ny version av en tjänst.
- **Exempel**: Om endast en mikrotjänst uppdateras, behöver endast dess pipeline köras.

### **Tydliga Docker-taggar**:
- Varje mikrotjänst kan bygga och tagga sin Docker-image med en versionsetikett eller `latest` och sedan publicera den till ett container registry.
- **Exempel på taggning**:
  - `my-service:1.0.0`
  - `user-service:2.1.3`
  - `product-service:latest`

### **Isolerad utveckling**:
- Team som arbetar på olika mikrotjänster kan hantera sina tjänster oberoende av andra, utan att behöva navigera genom ett stort, gemensamt repository.
