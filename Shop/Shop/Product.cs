namespace Shop;

/// <summary>
/// Товар магазина
/// </summary>
public class Product
{
    /// <summary>
    /// ID товара
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена за один товар
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ID поставщика
    /// </summary>
    public int SupplierId { get; set; }

    /// <summary>
    /// ID категории
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Количество на складе
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Общая стоимость товара 
    /// </summary>
    public double TotalPrice
    {
        get { return Price * Quantity; }
    }

    /// <summary>
    /// Является ли товар дорогим 
    /// </summary>
    public bool IsExpensive
    {
        get { return Price > 10000; }
    }

    /// <summary>
    /// Возвращает информацию о товаре
    /// </summary>
    public string GetInfo()
    {
        return $"{Name} ({Price} руб., {Quantity} шт.)";
    }
}