namespace Shop;

/// <summary>
/// Чтение данных из CSV
/// </summary>
public class CsvRepository
{
    private string _basePath;

    /// <summary>
    /// Конструктор с указанием пути к папке
    /// </summary>
    public CsvRepository(string basePath)
    {
        _basePath = basePath;
    }

    /// <summary>
    /// Читает поставщиков
    /// </summary>
    public List<Supplier> GetSuppliers()
    {
        List<Supplier> result = new List<Supplier>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "suppliers.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            Supplier s = new Supplier();
            s.Id = int.Parse(parts[0]);
            s.Name = parts[1];
            s.Country = parts[2];

            result.Add(s);
        }

        return result;
    }

    /// <summary>
    /// Читает категории
    /// </summary>
    public List<Category> GetCategories()
    {
        List<Category> result = new List<Category>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "categories.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            Category c = new Category();
            c.Id = int.Parse(parts[0]);
            c.Name = parts[1];
            c.Description = parts[2];

            result.Add(c);
        }

        return result;
    }

    /// <summary>
    /// Читает товары
    /// </summary>
    public List<Product> GetProducts()
    {
        List<Product> result = new List<Product>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "products.csv"));

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 6) continue;

            Product p = new Product();
            p.Id = int.Parse(parts[0]);
            p.Name = parts[1];
            p.Price = double.Parse(parts[2]);
            p.SupplierId = int.Parse(parts[3]);
            p.CategoryId = int.Parse(parts[4]);
            p.Quantity = int.Parse(parts[5]);

            result.Add(p);
        }

        return result;
    }
}