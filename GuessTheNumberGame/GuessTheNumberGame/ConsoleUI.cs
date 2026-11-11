namespace GuessNumber.Core;

/// <summary>
/// Консольный интерфейс для взаимодействия с игрой.
/// Отвечает только за ввод и вывод текста.
/// </summary>
public class ConsoleUI
{
    private readonly IGame _game;
    private readonly GameSettings _settings;
    private readonly IStatisticsService _stats; 

    private bool _isGameActive;
    private int _currentAttempts;

    /// <summary>
    /// Инициализирует интерфейс и подписывается на события игры.
    /// </summary>
    public ConsoleUI(IGame game, GameSettings settings, IStatisticsService stats)
    {
        _game = game;
        _settings = settings;
        _stats = stats;

        _game.OnGuessMade += HandleGuessMade;
        _game.OnGameOver += HandleGameOver;
    }

    /// <summary>
    /// Запускает основной цикл игры в консоли.
    /// </summary>
    public void Start()
    {
        Console.WriteLine($"Игра 'Угадай число' (Сложность: {_settings.Level})");
        Console.WriteLine($"Я загадал число от {_settings.MinValue} до {_settings.MaxValue}. У тебя {_settings.MaxAttempts} попыток.");

        _game.StartNewGame();

        _isGameActive = true;
        _currentAttempts = 0;

        while (_isGameActive)
        {
            Console.Write("\nВведи свой вариант: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Ошибка! Введи целое число.");
                continue;
            }

            _currentAttempts++; 
            _game.MakeGuess(guess);
        }
    }

    /// <summary>
    /// Обработчик события: выводит подсказку.
    /// </summary>
    private void HandleGuessMade(object? sender, GuessEventArgs e)
    {
        Console.WriteLine($"{e.Hint}! Осталось попыток: {e.AttemptsLeft}");
    }

    /// <summary>
    /// Обработчик события: выводит результат игры и сохраняет статистику.
    /// </summary>
    private void HandleGameOver(object? sender, GameOverEventArgs e)
    {
        _isGameActive = false;

        if (e.IsWin)
        {
            Console.WriteLine($"Поздравляю! Ты угадал число! 🎉 (Попыток: {_currentAttempts})");
        }
        else
        {
            Console.WriteLine($"Ты проиграл. Я загадал число {e.SecretNumber}.");
        }

        _stats.SaveResult(e.IsWin, _currentAttempts, _settings.Level);
    }
}