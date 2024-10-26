   /*
   Single Responsibility Principle (SRP):
   En klass ska bara ha en anledning att ändras, vilket innebär att den endast ska ha ett ansvar eller en uppgift.

   Exempel:
   Om du har en klass som både bearbetar ordrar och skickar notifikationer bryter det mot SRP. 
   Den har två ansvarsområden, och om någon del av denna funktionalitet behöver ändras påverkar det hela klassen. 
   Lösningen är att separera ansvaret så att en klass bearbetar ordrar och en annan skickar notifikationer.
   */
   
   public class OrderProcessor
   {
       public void ProcessOrder(Order order)
       {
           // Bearbeta order
       }
   }

   public class NotificationService
   {
       public void SendNotification(Order order)
       {
           // Skicka notifikation
       }
   }