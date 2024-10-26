   /*
   Open/Closed Principle (OCP):
   Programvaruenheter ska vara öppna för utökning men stängda för modifiering. 
   Du ska kunna lägga till ny funktionalitet utan att behöva ändra befintlig kod.

   Exempel:
   Om en betalningsklass har en metod som hanterar olika betalningsmetoder med if-satser, så bryter den mot OCP. 
   Varje gång en ny betalningsmetod läggs till, måste klassen ändras. 
   Genom att använda arv kan du skapa nya betalningsklasser utan att modifiera den ursprungliga koden.
   */
    
   public abstract class Payment
   {
       public abstract void Process();
   }

   public class CreditCardPayment : Payment
   {
       public override void Process()
       {
           // Bearbeta kreditkort
       }
   }

   public class PayPalPayment : Payment
   {
       public override void Process()
       {
           // Bearbeta PayPal
       }
   }

   public class PaymentService
   {
       public void ProcessPayment(Payment payment)
       {
           payment.Process();
       }
   }
