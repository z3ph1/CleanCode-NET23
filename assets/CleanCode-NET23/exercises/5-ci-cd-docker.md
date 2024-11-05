# CI/CD Övningar med Docker

## 1. Grundläggande Docker Image Bygg och Push
- **Mål:** Bygg en Docker-bild av ett enkelt .NET Core-projekt och ladda upp den till en Docker Registry.
- **Steg:**
  1. Skriv en Dockerfile som bygger projektet.
  2. Använd Docker CLI för att bygga bilden.
  3. Logga in på Docker Hub (eller en annan registry som Azure Container Registry).
  4. Push din bild till registret.
- **Bonus:** Skapa en GitHub Action eller Azure Pipeline för att automatisera bygg- och push-processen när nya commits görs.

## 2. Automatisk Bilduppdatering på Miljö
- **Mål:** Skapa en CI/CD-pipeline som automatiskt uppdaterar en miljö med senaste Docker-bild.
- **Steg:**
  1. Skapa en YAML-baserad pipeline (GitHub Actions eller Azure DevOps) för att bygga och ladda upp Docker-bilder till en registry.
  2. Lägg till ett steg som drar den senaste bilden till en testmiljö.
  3. Använd en Docker Compose-fil för att definiera applikationen och dess beroenden.
- **Bonus:** Implementera miljövariabler för olika miljöinställningar (t.ex. utveckling, test, produktion).

## 3. Rullande Uppdateringar med Docker och CI/CD
- **Mål:** Skapa en CI/CD-pipeline som hanterar rullande uppdateringar utan driftstopp.
- **Steg:**
  1. Konfigurera en Docker Swarm- eller Kubernetes-kluster för att hantera flera instanser av applikationen.
  2. Skapa en pipeline som bygger och pushar en ny bild till registret.
  3. Använd en Kubernetes YAML-konfiguration eller Docker Compose för att gradvis uppdatera poddar/containers.
  4. Se till att minst en instans alltid är aktiv under uppdateringen.
- **Bonus:** Automatisera rollback om uppdateringen misslyckas.

## 4. CI/CD med Testning i Docker-kontainrar
- **Mål:** Integrera enhetstestning i din CI/CD-pipeline med Docker.
- **Steg:**
  1. Skapa en Dockerfile som inkluderar ett steg för att köra enhetstester.
  2. Bygg och kör testerna i en container som en del av CI/CD-pipelinen.
  3. Misslyckas testerna? Låt pipeline stanna och visa loggar för att hjälpa felsökning.
- **Bonus:** Använd rapporteringsverktyg som kan generera testrapporter, t.ex. med JUnit-format.

## 5. Multi-Stage Docker Builds för Optimerade Bilder
- **Mål:** Använd multi-stage builds för att minska storleken på din Docker-bild.
- **Steg:**
  1. Skapa en Dockerfile med flera byggsteg, där det första steget bygger och det andra kör en slimmad bild.
  2. Automatisera byggprocessen i en CI/CD-pipeline för att säkerställa att varje ny commit genererar en slimmad bild.
  3. Kontrollera storleksskillnaden mellan single-stage och multi-stage builds.
- **Bonus:** Jämför prestanda på olika miljöer och optimera för snabbare container-starttid.

Dessa övningar hjälper dig att bygga, testa och distribuera med Docker samt att förstå viktiga koncept inom CI/CD.
