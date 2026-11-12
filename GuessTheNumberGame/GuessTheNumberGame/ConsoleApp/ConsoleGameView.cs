using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;

namespace GuessNumber.ConsoleApp;

/// <summary>
/// Реализация отображения игрового процесса в стандартной консоли.
/// </summary>
public class ConsoleGameView : IGameView
{
    public void ShowWelcome(GameSettings settings)
    {
        Console.Clear();
        Console.WriteLine($" Игра 'Угадай число' (Уровень: {settings.DifficultyName})");
        Console.WriteLine($"Загадано число от {settings.MinValue} до {settings.MaxValue}. Всего попыток: {settings.MaxAttempts}.\n");
    }

    public void ShowGuessFeedback(GuessResult result, int attemptsLeft)
    {
        string hint = result switch
        {
            GuessResult.TooLow => "Больше",
            GuessResult.TooHigh => "Меньше",
            _ => string.Empty
        };

        Console.WriteLine($"Подсказка: {hint}! Осталось попыток: {attemptsLeft}.\n");
    }

    public void ShowGameOver(bool isWin, int secretNumber, int attemptsUsed)
    {
        if (isWin)
        {
            Console.WriteLine($"\n🎉 Число {secretNumber} отгадано за {attemptsUsed} попыток.");
        }
        else
        {
            Console.WriteLine($"\n💀 Поражение. Было загадано число: {secretNumber}.");
        }

        Console.WriteLine("Результат игры сохранен в файл статистики.");
    }
}
