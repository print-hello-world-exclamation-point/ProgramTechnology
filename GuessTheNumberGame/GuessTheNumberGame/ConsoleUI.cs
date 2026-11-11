using System;

namespace GuessNumber.Core;

/// <summary>
/// Консольный интерфейс для взаимодействия с игрой.
/// </summary>
public class ConsoleUI
{
    private readonly IGame _game;
    private readonly GameSettings _settings;
    private readonly IStatisticsService _stats;

    private bool _isGameActive;

    public ConsoleUI(IGame game, GameSettings settings, IStatisticsService stats)
    {
        _game = game;
        _settings = settings;
        _stats = stats;

        _game.OnGuessMade += HandleGuessMade;
        _game.OnGameOver += HandleGameOver;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- Игра 'Угадай число' (Уровень: {_settings.Level}) ---");
        Console.WriteLine($"Я загадал число от {_settings.MinValue} до {_settings.MaxValue}.");

        _game.StartNewGame();
        _isGameActive = true;

        while (_isGameActive)
        {
            Console.Write($"\nВведи вариант (осталось попыток: {_game.AttemptsLeft}): ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Ошибка! Введи целое число.");
                continue;
            }

            _game.MakeGuess(guess);
        }
    }

    private void HandleGuessMade(object? sender, GuessEventArgs e)
    {
        Console.WriteLine($"Подсказка: {e.Hint}!");
    }

    private void HandleGameOver(object? sender, GameOverEventArgs e)
    {
        _isGameActive = false;

        if (e.IsWin)
        {
            Console.WriteLine($"\n🎉 Поздравляю! Ты угадал число!");
        }
        else
        {
            Console.WriteLine($"\n💀 Ты проиграл. Было загадано: {e.SecretNumber}.");
        }

        int usedAttempts = _settings.MaxAttempts - _game.AttemptsLeft;
        _stats.SaveResult(e.IsWin, usedAttempts, _settings.Level);
        Console.WriteLine("Результат сохранен в stats.txt.");
    }
}