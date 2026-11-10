namespace GuessNumber.Core;

/// <summary>
/// Консольный интерфейс для взаимодействия с игрой.
/// Отвечает только за ввод и вывод текста.
/// </summary>
public class ConsoleUI
{
    private readonly IGame _game;
    private readonly GameSettings _settings;

    /// <summary>
    /// Инициализирует интерфейс и подписывается на события игры.
    /// </summary>
    public ConsoleUI(IGame game, GameSettings settings)
    {
        _game = game;
        _settings = settings;

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

        bool isGameRunning = true;

        while (isGameRunning)
        {
            Console.Write("\nВведи свой вариант: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Ошибка! Введи целое число.");
                continue;
            }

            _game.MakeGuess(guess);

            if (input != null && _game is GameEngine)
            {
            }

            if (!IsGameActive) break;
        }
    }

    private bool IsGameActive = true;

    /// <summary>
    /// Обработчик события: выводит подсказку.
    /// </summary>
    private void HandleGuessMade(object? sender, GuessEventArgs e)
    {
        Console.WriteLine($"{e.Hint}! Осталось попыток: {e.AttemptsLeft}");
    }

    /// <summary>
    /// Обработчик события: выводит результат игры.
    /// </summary>
    private void HandleGameOver(object? sender, GameOverEventArgs e)
    {
        IsGameActive = false; 

        if (e.IsWin)
        {
            Console.WriteLine("Поздравляю! Ты угадал число! 🎉");
        }
        else
        {
            Console.WriteLine($"Ты проиграл. Я загадал число {e.SecretNumber}.");
        }
    }
}