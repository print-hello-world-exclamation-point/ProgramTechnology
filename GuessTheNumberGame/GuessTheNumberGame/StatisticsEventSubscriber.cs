using GuessNumber.Core.Events;
using GuessNumber.Core.Interfaces;

namespace GuessNumber.Core.Services;

/// <summary>
/// Подписчик на события игры, автоматически сохраняющий статистику при завершении партии.
/// </summary>
public class StatisticsEventSubscriber : IDisposable
{
    private readonly IGameEngine _gameEngine;
    private readonly IStatisticsRepository _repository;

    public StatisticsEventSubscriber(IGameEngine gameEngine, IStatisticsRepository repository)
    {
        _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _gameEngine.GameOver += OnGameOver;
    }

    private void OnGameOver(object? sender, GameOverEventArgs e)
    {
        _repository.Save(e.IsWin, e.AttemptsUsed, e.DifficultyName);
    }

    public void Dispose()
    {
        _gameEngine.GameOver -= OnGameOver;
    }
}
