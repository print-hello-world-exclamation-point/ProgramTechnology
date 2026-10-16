using System;

namespace Shapes;

/// <summary>
/// Круг.
/// </summary>
public class Circle : Shape, IScalable
{
    /// <summary>
    /// Радиус круга.
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Диаметр круга.
    /// </summary>
    public double Diameter => Radius * 2;

    /// <summary>
    /// Создаёт круг с указанием названия, цвета и радиуса.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="color">Цвет фигуры.</param>
    /// <param name="radius">Радиус круга.</param>
    public Circle(string name, string color, double radius) : base(name, color)
    {
        Radius = radius;
        Kind = ShapeKind.Circle;
    }

    /// <summary>
    /// Создаёт круг с указанием названия и радиуса.
    /// </summary>
    /// <param name="name">Название фигуры.</param>
    /// <param name="radius">Радиус круга.</param>
    public Circle(string name, double radius) : this(name, "black", radius)
    {
    }

    /// <summary>
    /// Возвращает площадь круга.
    /// </summary>
    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    /// Масштабирует круг в указанное число раз.
    /// </summary>
    /// <param name="factor">Коэффициент масштабирования.</param>
    public void Scale(double factor)
    {
        Radius *= factor;
    }

    /// <summary>
    /// Возвращает текстовое представление круга.
    /// </summary>
    public override string ToString()
    {
        return $"[Circle] {Color}, kind: {Kind}, r={Radius}";
    }
}