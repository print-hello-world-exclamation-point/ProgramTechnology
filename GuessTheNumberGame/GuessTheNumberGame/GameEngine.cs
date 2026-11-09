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

    // Реализуем события из интерфейса
    public event EventHandler<GuessEventArgs>? OnGuessMade;
    public event EventHandler<GameOverEventArgs>? OnGameOver;

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

        // Если угадал
        if (guess == _secretNumber)
        {
            OnGameOver?.Invoke(this, new GameOverEventArgs(true, _secretNumber));
            return;
        }

        // Если не угадал, определяем подсказку
        string hint = guess < _secretNumber ? "Больше" : "Меньше";
        int attemptsLeft = _settings.MaxAttempts - _currentAttempt;

        // Вызываем событие попытки (передаем данные наружу)
        OnGuessMade?.Invoke(this, new GuessEventArgs(guess, hint, attemptsLeft));

        // Если попытки закончились
        if (attemptsLeft <= 0)
        {
            OnGameOver?.Invoke(this, new GameOverEventArgs(false, _secretNumber));
        }
    }
}