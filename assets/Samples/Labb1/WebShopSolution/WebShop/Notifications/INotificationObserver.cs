namespace WebShop.Notifications
{
    // Gränssnitt för notifieringsobservatörer enligt Observer Pattern
    public interface INotificationObserver
    {
        void Update(Product product); // Metod som kallas när en ny produkt läggs till
    }
}
