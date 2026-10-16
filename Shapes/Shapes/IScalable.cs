namespace Shapes;

/// <summary>
/// Объект, который можно масштабировать.
/// </summary>
public interface IScalable
{
    /// <summary>
    /// Масштабирует фигуру в указанное число раз.
    /// </summary>
    /// <param name="factor">Коэффициент масштабирования.</param>
    void Scale(double factor);
}