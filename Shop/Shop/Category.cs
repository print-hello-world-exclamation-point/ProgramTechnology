namespace Shop;

/// <summary>
/// Категория товаров
/// </summary>
public class Category
{
    /// <summary>
    /// ID категории
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание категории
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Информация о категории
    /// </summary>
    public string Info
    {
        get { return $"{Name} — {Description}"; }
    }
}