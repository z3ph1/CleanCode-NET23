   /*
   Interface Segregation Principle (ISP):
   Klienter ska inte tvingas implementera gränssnitt som de inte använder. Istället för att skapa ett stort gränssnitt, bryt ned det i mindre, mer specifika gränssnitt som klienterna verkligen behöver.

   Exempel:
   Ett multifunktionellt maskininterface som tvingar en enkel skrivare att implementera faxfunktionalitet är ett brott mot ISP. Lösningen är att bryta upp gränssnittet så att skrivare endast implementerar de funktioner de behöver.
   */

   public interface IPrinter
   {
       void Print(Document document);
   }

   public interface IScanner
   {
       void Scan(Document document);
   }

   public interface IFax
   {
       void Fax(Document document);
   }

   public class Printer : IPrinter
   {
       public void Print(Document document) { }
   }

   public class MultiFunctionMachine : IPrinter, IScanner, IFax
   {
       public void Print(Document document) { }
       public void Scan(Document document) { }
       public void Fax(Document document) { }
   }

