/*
    Repository:
    The Repository Pattern is a design pattern used in software development to abstract the data access layer, allowing you to separate the business logic from the data access logic.
    It is commonly used in Domain-Driven Design (DDD) and works well with Object-Relational Mapping (ORM) frameworks like Entity Framework in .NET.

    Key Concept
    A repository acts as a mediator between the domain and the data mapping layers, providing a centralized place to perform data operations.
    It provides an abstraction over the persistence mechanism, such as a database, allowing the underlying data source to change without affecting the business logic.
*/

public interface IProductRepository
{
    Product GetById(int id);
    IEnumerable<Product> GetAll();
    void Add(Product product);
    void Remove(int id);
}

public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public Product GetById(int id) => _context.Products.Find(id);

    public IEnumerable<Product> GetAll() => _context.Products.ToList();

    public void Add(Product product) => _context.Products.Add(product);

    public void Remove(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
            _context.Products.Remove(product);
    }
}