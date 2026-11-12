using GuessNumber.Core.Events;
using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;

namespace GuessNumber.Core.Services;

/// <summary>
/// Управляет ходом одной игровой сессии, связывая движок игры с абстракциями ввода и вывода.
/// </summary>
public class GameSessionController : IDisposable
{
    private readonly IGameEngine _gameEngine;
    private readonly IUserInput _userInput;
    private readonly IGameView _gameView;
    private readonly GameSettings _settings;

    private bool _isRunning;

    public GameSessionController(IGameEngine gameEngine, IUserInput userInput, IGameView gameView, GameSettings settings)
    {
        _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        _userInput = userInput ?? throw new ArgumentNullException(nameof(userInput));
        _gameView = gameView ?? throw new ArgumentNullException(nameof(gameView));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));

        _gameEngine.GuessMade += OnGuessMade;
        _gameEngine.GameOver += OnGameOver;
    }

    /// <summary>
    /// Запускает и ведет игровой цикл до победы или окончания попыток.
    /// </summary>
    public void Run()
    {
        _gameView.ShowWelcome(_settings);
        _gameEngine.StartNewGame();
        _isRunning = true;

        while (_isRunning)
        {
            int guess = _userInput.ReadGuess(_settings.MinValue, _settings.MaxValue);
            _gameEngine.MakeGuess(guess);
        }
    }

    private void OnGuessMade(object? sender, GuessMadeEventArgs e)
    {
        _gameView.ShowGuessFeedback(e.Result, e.AttemptsLeft);
    }

    private void OnGameOver(object? sender, GameOverEventArgs e)
    {
        _isRunning = false;
        _gameView.ShowGameOver(e.IsWin, e.SecretNumber, e.AttemptsUsed);
    }

    public void Dispose()
    {
        _gameEngine.GuessMade -= OnGuessMade;
        _gameEngine.GameOver -= OnGameOver;
    }
}