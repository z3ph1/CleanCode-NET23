   /*
   Liskov Substitution Principle (LSP):
   Subtyper ska kunna ersätta sina basklasser utan att ändra programmets korrekthet. 
   Ett objekt av en subklass ska kunna användas var som helst där ett objekt av basklassen kan användas.

   Exempel:
   Anta att du har en rektangelklass och en fyrkantklass som ärver från rektangel. 
   Om fyrkanten beter sig annorlunda när dess egenskaper ändras (t.ex. genom att tvinga höjden och bredden att alltid vara samma) bryter det mot LSP. 
   Du bör istället definiera en abstrakt formklass och låta varje klass ha sitt eget beteende.
   */
   
   public abstract class Shape
   {
       public abstract int Area();
   }

   public class Rectangle : Shape
   {
       public int Width { get; set; }
       public int Height { get; set; }

       public override int Area()
       {
           return Width * Height;
       }
   }

   public class Square : Shape
   {
       public int Side { get; set; }

       public override int Area()
       {
           return Side * Side;
       }
   }