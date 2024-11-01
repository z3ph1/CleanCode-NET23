using WebShop.Notifications;
using WebShop.Repositories;

namespace WebShop.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Hämta produkter från repository
        public IProductRepository Products { get; private set; }

        private readonly ProductSubject _productSubject;

        // Konstruktor används för tillfället av Observer pattern
        public UnitOfWork(ProductSubject productSubject = null)
        {
            Products = null;

            // Om inget ProductSubject injiceras, skapa ett nytt
            _productSubject = productSubject ?? new ProductSubject();

            // Registrera standardobservatörer
            _productSubject.Attach(new EmailNotification());
        }

        public void NotifyProductAdded(Product product)
        {
            _productSubject.Notify(product);
        }
    }
}
