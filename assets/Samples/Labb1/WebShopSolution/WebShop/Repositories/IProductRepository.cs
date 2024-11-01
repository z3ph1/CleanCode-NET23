namespace WebShop.Repositories
{
    // Gränssnitt för produktrepositoryt enligt Repository Pattern
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(); // Hämtar alla produkter
        void Add(Product product); // Lägger till en ny produkt
    }
}
