namespace Shapes;

/// <summary>
/// Прямоугольник.
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Ширина прямоугольника.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Высота прямоугольника.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Является ли прямоугольник квадратом.
    /// </summary>
    public bool IsSquare => Width == Height;

    /// <summary>
    /// Создаёт прямоугольник с указанием названия, цвета, ширины и высоты.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    public Rectangle(string name, string color, double width, double height) : base(name, color)
    {
        Width = width;
        Height = height;
        Kind = ShapeKind.Rectangle;
    }

    /// <summary>
    /// Создаёт прямоугольник с указанием названия, ширины и высоты.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    public Rectangle(string name, double width, double height) : this(name, "black", width, height)
    {
    }

    /// <summary>
    /// Возвращает площадь прямоугольника.
    /// </summary>
    public override double GetArea()
    {
        return Width * Height;
    }

    /// <summary>
    /// Возвращает текстовое представление прямоугольника.
    /// </summary>
    public override string ToString()
    {
        return $"[Rectangle] {Color}, kind: {Kind}, {Width}x{Height}";
    }
}