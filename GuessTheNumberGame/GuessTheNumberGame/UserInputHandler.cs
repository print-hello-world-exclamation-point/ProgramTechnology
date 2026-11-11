namespace GuessNumber.Core;

/// <summary>
/// Обработчик пользовательского ввода в консоли (выбор настроек).
/// </summary>
public class UserInputHandler
{
    /// <summary>
    /// Запрашивает у пользователя уровень сложности.
    /// </summary>
    public Difficulty AskDifficulty()
    {
        Console.WriteLine("Выберите уровень сложности:");
        Console.WriteLine("1 - Легкий (1-10, 5 попыток)");
        Console.WriteLine("2 - Средний (1-50, 7 попыток)");
        Console.WriteLine("3 - Сложный (1-100, 10 попыток)");
        Console.Write("Ваш выбор: ");

        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                if (choice == 1) return Difficulty.Easy;
                if (choice == 2) return Difficulty.Medium;
                if (choice == 3) return Difficulty.Hard;
            }
            Console.Write("Ошибка. Введите 1, 2 или 3: ");
        }
    }
}