   /*
   Dependency Inversion Principle (DIP):
   Högre nivåers moduler ska inte bero på lägre nivåers moduler. Båda ska bero på abstraktioner (gränssnitt). 
   Abstraktioner ska inte bero på detaljer, utan detaljer ska bero på abstraktioner.

   Exempel:
   Om en notifieringsklass direkt skapar en instans av en e-posttjänst bryter den mot DIP, eftersom den är hårt kopplad till en specifik implementering. 
   Genom att använda ett gränssnitt kan notifieringsklassen istället bero på en abstraktion, vilket gör den mer flexibel och lättare att utöka.
   */

   public interface IMessageService
   {
       void SendMessage(string message);
   }

   public class EmailService : IMessageService
   {
       public void SendMessage(string message)
       {
           // Skicka e-post
       }
   }

   public class Notification
   {
       private readonly IMessageService _messageService;

       public Notification(IMessageService messageService)
       {
           _messageService = messageService;
       }

       public void SendNotification(string message)
       {
           _messageService.SendMessage(message);
       }
   }

