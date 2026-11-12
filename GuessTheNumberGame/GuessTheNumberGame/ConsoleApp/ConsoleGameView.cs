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
        Console.WriteLine($"--- Игра 'Угадай число' (Уровень: {settings.DifficultyName}) ---");
        Console.WriteLine($"Я загадал число от {settings.MinValue} до {settings.MaxValue}. Всего попыток: {settings.MaxAttempts}.\n");
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
            Console.WriteLine($"\n🎉 Поздравляю! Ты угадал число {secretNumber} за {attemptsUsed} попыток!");
        }
        else
        {
            Console.WriteLine($"\n💀 Ты проиграл. Было загадано число: {secretNumber}.");
        }

        Console.WriteLine("Результат игры сохранен в файл статистики.");
    }
}
