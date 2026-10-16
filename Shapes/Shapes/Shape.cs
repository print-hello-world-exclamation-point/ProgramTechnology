namespace Shapes;

/// <summary>
/// Базовый абстрактный класс геометрической фигуры.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Название фигуры.
    /// </summary>
    private string _name;

    /// <summary>
    /// Цвет фигуры.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Категория фигуры.
    /// </summary>
    public ShapeKind Kind { get; set; } = ShapeKind.Circle;

    /// <summary>
    /// Текстовая информация о фигуре.
    /// </summary>
    public string Info => $"{Kind} ({Color})";

    /// <summary>
    /// Создаёт фигуру с указанием названия и цвета.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    public Shape(string name, string color)
    {
        _name = name;
        Color = color;
    }

    /// <summary>
    /// Создаёт фигуру с указанием названия.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    public Shape(string name) : this(name, "black")
    {
    }

    /// <summary>
    /// Возвращает площадь фигуры.
    /// </summary>
    public abstract double GetArea();

    /// <summary>
    /// Возвращает название фигуры.
    /// </summary>
    public string GetName()
    {
        return _name;
    }
}