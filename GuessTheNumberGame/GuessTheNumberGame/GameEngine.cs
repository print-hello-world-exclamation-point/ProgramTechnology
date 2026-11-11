namespace GuessNumber.Core;

/// <summary>
/// Основная реализация логики игры "Угадай число".
/// </summary>
public class GameEngine : IGame
{
    private readonly GameSettings _settings;
    private readonly Random _random;

    private int _secretNumber;
    private int _currentAttempt;

    public event EventHandler<GuessEventArgs>? OnGuessMade;
    public event EventHandler<GameOverEventArgs>? OnGameOver;

    /// <summary>Текущее количество оставшихся попыток.</summary>
    public int AttemptsLeft { get; private set; }

    /// <summary>
    /// Инициализирует движок игры с указанными настройками.
    /// </summary>
    public GameEngine(GameSettings settings)
    {
        _settings = settings;
        _random = new Random();
    }

    /// <summary>
    /// Начинает новую игру: загадывает число и сбрасывает счетчик попыток.
    /// </summary>
    public void StartNewGame()
    {
        _secretNumber = _random.Next(_settings.MinValue, _settings.MaxValue + 1);
        _currentAttempt = 0;
    }

    /// <summary>
    /// Проверяет введенное число и вызывает соответствующие события.
    /// </summary>
    public void MakeGuess(int guess)
    {
        _currentAttempt++;

        if (guess == _secretNumber)
        {
            OnGameOver?.Invoke(this, new GameOverEventArgs(true, _secretNumber));
            return;
        }

        string hint = guess < _secretNumber ? "Больше" : "Меньше";
        int attemptsLeft = _settings.MaxAttempts - _currentAttempt;

        OnGuessMade?.Invoke(this, new GuessEventArgs(guess, hint, attemptsLeft));

        if (attemptsLeft <= 0)
        {
            OnGameOver?.Invoke(this, new GameOverEventArgs(false, _secretNumber));
        }
    }
}