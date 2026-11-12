using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;

namespace GuessNumber.ConsoleApp;

/// <summary>
/// Реализация пользовательского ввода через стандартную консоль.
/// </summary>
public class ConsoleUserInput : IUserInput
{
    public GameSettings SelectDifficulty(IReadOnlyList<GameSettings> availableDifficulties)
    {
        Console.WriteLine("Выберите уровень сложности:");
        for (int i = 0; i < availableDifficulties.Count; i++)
        {
            var level = availableDifficulties[i];
            Console.WriteLine($"{i + 1} - {level.DifficultyName} ({level.MinValue}-{level.MaxValue}, попыток: {level.MaxAttempts})");
        }

        while (true)
        {
            Console.Write("Ваш выбор: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= availableDifficulties.Count)
            {
                return availableDifficulties[choice - 1];
            }

            Console.WriteLine($"Ошибка! Введите число от 1 до {availableDifficulties.Count}.");
        }
    }

    public int ReadGuess(int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write($"Введите число от {minValue} до {maxValue}: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Ошибка! Введите целое число.");
                continue;
            }

            if (guess < minValue || guess > maxValue)
            {
                Console.WriteLine($"Ошибка! Число должно быть в диапазоне от {minValue} до {maxValue}.");
                continue;
            }

            return guess;
        }
    }
}