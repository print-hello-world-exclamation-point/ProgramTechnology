namespace Shop;

/// <summary>
/// Поставщик товаров
/// </summary>
public class Supplier
{
    /// <summary>
    /// ID поставщика
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название компании
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Страна поставщика
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Является ли поставщик иностранным
    /// </summary>
    public bool IsForeign
    {
        get { return Country != "Россия"; }
    }

    /// <summary>
    /// Возвращает информацию о поставщике
    /// </summary>
    public string GetInfo()
    {
        return $"{Name} ({Country})";
    }
}