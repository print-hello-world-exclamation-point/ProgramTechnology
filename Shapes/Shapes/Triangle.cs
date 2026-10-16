namespace Shapes;

/// <summary>
/// Треугольник.
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Основание треугольника.
    /// </summary>
    public double Base { get; set; }

    /// <summary>
    /// Высота треугольника.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Является ли треугольник прямоугольным.
    /// </summary>
    public bool IsRight => Base > 0 && Height > 0;

    /// <summary>
    /// Создаёт треугольник с указанием названия, цвета, основания и высоты.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    /// <param name="base">Основание.</param>
    /// <param name="height">Высота.</param>
    public Triangle(string name, string color, double @base, double height) : base(name, color)
    {
        Base = @base;
        Height = height;
        Kind = ShapeKind.Triangle;
    }

    /// <summary>
    /// Создаёт треугольник с указанием названия, основания и высоты.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="base">Основание.</param>
    /// <param name="height">Высота.</param>
    public Triangle(string name, double @base, double height) : this(name, "black", @base, height)
    {
    }

    /// <summary>
    /// Возвращает площадь треугольника.
    /// </summary>
    public override double GetArea()
    {
        return 0.5 * Base * Height;
    }

    /// <summary>
    /// Возвращает текстовое представление треугольника.
    /// </summary>
    public override string ToString()
    {
        return $"[Triangle] {Color}, kind: {Kind}, b={Base}, h={Height}";
    }
}