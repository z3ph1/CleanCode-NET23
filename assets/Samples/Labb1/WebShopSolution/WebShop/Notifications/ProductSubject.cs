namespace WebShop.Notifications
{
    // Subject som håller reda på observatörer och notifierar dem
    public class ProductSubject
    {
        // Lista över registrerade observatörer
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            // Lägg till en observatör
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            // Ta bort en observatör
            _observers.Remove(observer);
        }

        public void Notify(Product product)
        {
            // Notifiera alla observatörer om en ny produkt
            foreach (var observer in _observers)
            {
                observer.Update(product);
            }
        }
    }
}
