namespace Shapes;

/// <summary>
/// Точка входа. Демонстрирует полиморфизм, интерфейс и проверку типа.
/// </summary>
public class Program
{
    /// <summary>
    /// Запускает демонстрацию работы с фигурами.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle("red", "red", 5),
            new Rectangle("blue", "blue", 4, 6),
            new Triangle("green", "green", 3, 8)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape);

            if (shape is Circle circle)
            {
                Console.WriteLine($"  diameter: {circle.Diameter}, area: {Math.Round(shape.GetArea(), 2)}");
            }
            else
            {
                Console.WriteLine($"  area: {Math.Round(shape.GetArea(), 2)}");
            }

            if (shape is IScalable scalable)
            {
                scalable.Scale(2);
                Console.WriteLine($"{shape.Kind} scaled by 2.");
            }
            else
            {
                Console.WriteLine($"{shape.Kind} cannot scale.");
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}