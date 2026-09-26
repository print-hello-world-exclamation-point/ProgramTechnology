namespace Shop;

/// <summary>
/// Тестовых данные
/// </summary>
public class InMemoryRepository
{
    private List<Supplier> _suppliers;
    private List<Category> _categories;
    private List<Product> _products;

    /// <summary>
    /// Конструктор заполняет списки данными
    /// </summary>
    public InMemoryRepository()
    {
        _suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "Samsung", Country = "Южная Корея" },
            new Supplier { Id = 2, Name = "Bosch", Country = "Германия" },
            new Supplier { Id = 3, Name = "Zara", Country = "Испания" },
            new Supplier { Id = 4, Name = "Xiaomi", Country = "Китай" },
            new Supplier { Id = 5, Name = "Redmond", Country = "Россия" }
        };

        _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Электроника", Description = "бытовая техника" },
            new Category { Id = 2, Name = "Одежда", Description = "мужская и женская" },
            new Category { Id = 3, Name = "Бытовая химия", Description = "средства для дома" }
        };

        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 75000, SupplierId = 1, CategoryId = 1, Quantity = 10 },
            new Product { Id = 2, Name = "Смартфон", Price = 45000, SupplierId = 1, CategoryId = 1, Quantity = 15 },
            new Product { Id = 3, Name = "Пылесос", Price = 12000, SupplierId = 2, CategoryId = 1, Quantity = 8 },
            new Product { Id = 4, Name = "Куртка", Price = 12000, SupplierId = 3, CategoryId = 2, Quantity = 20 },
            new Product { Id = 5, Name = "Джинсы", Price = 5000, SupplierId = 3, CategoryId = 2, Quantity = 30 },
            new Product { Id = 6, Name = "Порошок", Price = 800, SupplierId = 5, CategoryId = 3, Quantity = 100 },
            new Product { Id = 7, Name = "Планшет", Price = 25000, SupplierId = 4, CategoryId = 1, Quantity = 12 }
        };
    }

    /// <summary>
    /// Возвращает список поставщиков
    /// </summary>
    public List<Supplier> GetSuppliers() { return _suppliers; }

    /// <summary>
    /// Возвращает список категорий
    /// </summary>
    public List<Category> GetCategories() { return _categories; }

    /// <summary>
    /// Возвращает список товаров
    /// </summary>
    public List<Product> GetProducts() { return _products; }
}