using GuessNumber.Core.Events;
using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;

namespace GuessNumber.Core.Services;

/// <summary>
/// Реализация правил и логики игры "Угадай число".
/// </summary>
public class GameEngine : IGameEngine
{
    private readonly GameSettings _settings;
    private readonly IRandomGenerator _randomGenerator;

    private int _secretNumber;
    private int _attemptsUsed;
    private bool _isGameOver;

    public event EventHandler<GuessMadeEventArgs>? GuessMade;
    public event EventHandler<GameOverEventArgs>? GameOver;

    public GameEngine(GameSettings settings, IRandomGenerator randomGenerator)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _randomGenerator = randomGenerator ?? throw new ArgumentNullException(nameof(randomGenerator));
    }

    public void StartNewGame()
    {
        _secretNumber = _randomGenerator.Next(_settings.MinValue, _settings.MaxValue);
        _attemptsUsed = 0;
        _isGameOver = false;
    }

    public void MakeGuess(int guess)
    {
        if (_isGameOver)
        {
            return;
        }

        _attemptsUsed++;

        if (guess == _secretNumber)
        {
            _isGameOver = true;
            GameOver?.Invoke(this, new GameOverEventArgs(
                isWin: true,
                secretNumber: _secretNumber,
                attemptsUsed: _attemptsUsed,
                difficultyName: _settings.DifficultyName));
            return;
        }

        GuessResult result = guess < _secretNumber ? GuessResult.TooLow : GuessResult.TooHigh;
        int attemptsLeft = _settings.MaxAttempts - _attemptsUsed;

        GuessMade?.Invoke(this, new GuessMadeEventArgs(result, attemptsLeft));

        if (attemptsLeft <= 0)
        {
            _isGameOver = true;
            GameOver?.Invoke(this, new GameOverEventArgs(
                isWin: false,
                secretNumber: _secretNumber,
                attemptsUsed: _attemptsUsed,
                difficultyName: _settings.DifficultyName));
        }
    }
}