namespace Shop;

class Program
{ 
    static void Main()
    {
        Console.WriteLine("Выберите источник данных:");
        Console.WriteLine("1 - InMemory");
        Console.WriteLine("2 - CSV");
        int choice = int.Parse(Console.ReadLine());

        List<Supplier> suppliers;
        List<Category> categories;
        List<Product> products;

        switch (choice)
        {
            case 1:
                var mem = new InMemoryRepository();
                suppliers = mem.GetSuppliers();
                categories = mem.GetCategories();
                products = mem.GetProducts();
                break;
            case 2:
                var csv = new CsvRepository("data");
                suppliers = csv.GetSuppliers();
                categories = csv.GetCategories();
                products = csv.GetProducts();
                break;
            default:
                Console.WriteLine("Неверный выбор");
                return;
        }

        Console.WriteLine($"Количество товаров: {products.Count}, категорий: {categories.Count}");

        Category foundCategory = FindCategory(products, categories, "Ноутбук");
        Product foundProduct = FindProductByName(products, "Ноутбук");
        if (foundCategory != null && foundProduct != null)
        {
            Supplier foundSupplier = FindSupplier(suppliers, foundProduct);
            Console.WriteLine($"Товар \"Ноутбук\" категории \"{foundCategory.Name}\" от \"{foundSupplier.Name}\"");
        }

        double total = GetTotalPrice(products);
        Console.WriteLine($"Общая стоимость: {total} руб.");

        Dictionary<string, Product> mostExpensive = GetMostExpensiveProductPerCategory(products, categories);
        Console.WriteLine("\nСамый дорогой товар в каждой категории:");
        foreach (var pair in mostExpensive)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value.Name} ({pair.Value.Price})");
        }

        Console.WriteLine("\nВсе товары:");
        PrintAllProducts(products, categories, suppliers);
    }

    /// <summary>
    /// Находит категорию по названию товара
    /// </summary>
    static Category FindCategory(List<Product> products, List<Category> categories, string productName)
    {
        foreach (Product p in products)
        {
            if (p.Name == productName)
            {
                foreach (Category c in categories)
                {
                    if (c.Id == p.CategoryId)
                        return c;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Находит товар по названию
    /// </summary>
    static Product FindProductByName(List<Product> products, string name)
    {
        foreach (Product p in products)
        {
            if (p.Name == name)
                return p;
        }
        return null;
    }

    /// <summary>
    /// Находит поставщика товара
    /// </summary>
    static Supplier FindSupplier(List<Supplier> suppliers, Product product)
    {
        foreach (Supplier s in suppliers)
        {
            if (s.Id == product.SupplierId)
                return s;
        }
        return null;
    }

    /// <summary>
    /// Считает суммарную стоимость всех товаров
    /// </summary>
    static double GetTotalPrice(List<Product> products)
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.TotalPrice;
        }
        return total;
    }

    /// <summary>
    /// Возвращает самый дорогой товар в каждой категории
    /// </summary>
    static Dictionary<string, Product> GetMostExpensiveProductPerCategory(List<Product> products, List<Category> categories)
    {
        Dictionary<string, Product> result = new Dictionary<string, Product>();

        foreach (Category c in categories)
        {
            Product mostExpensive = null;

            foreach (Product p in products)
            {
                if (p.CategoryId == c.Id)
                {
                    if (mostExpensive == null || p.Price > mostExpensive.Price)
                    {
                        mostExpensive = p;
                    }
                }
            }

            if (mostExpensive != null)
            {
                result.Add(c.Name, mostExpensive);
            }
        }

        return result;
    }

    /// <summary>
    /// Выводит все товары с категорией и поставщиком
    /// </summary>
    static void PrintAllProducts(List<Product> products, List<Category> categories, List<Supplier> suppliers)
    {
        foreach (Product p in products)
        {
            string categoryName = "";
            string supplierName = "";

            foreach (Category c in categories)
            {
                if (c.Id == p.CategoryId)
                {
                    categoryName = c.Name;
                    break;
                }
            }

            foreach (Supplier s in suppliers)
            {
                if (s.Id == p.SupplierId)
                {
                    supplierName = s.Name;
                    break;
                }
            }

            Console.WriteLine($"{p.Id}. {p.GetInfo()} | {categoryName} | {supplierName}");
        }
    }
}