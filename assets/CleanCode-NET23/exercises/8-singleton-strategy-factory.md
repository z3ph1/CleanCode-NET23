
# Design Patterns in C#

## 1. Singleton Pattern
### Uppgift:
Skapa en logger som använder Singleton-mönstret. Loggern ska:
1. Ha en metod `Log(string message)` som skriver loggmeddelanden till en fil.
2. Säkerställa att endast en instans av loggern existerar.
3. Vara trådsäker.

---

## 2. Strategy Pattern
### Uppgift:
Bygg ett betalningssystem med Strategy-mönstret. Systemet ska:
1. Stödja olika betalningsstrategier, t.ex. kreditkort och PayPal.
2. Låta användaren välja betalningsstrategi vid körning.

---

## 3. Factory Pattern
### Uppgift:
Implementera en fordonstillverkare som använder Factory-mönstret. Fordonstillverkaren ska:
1. Skapa fordon av olika typer: Bil, Motorcykel, och Lastbil.
2. Returnera objekt baserat på en användares val.
