using GuessNumber.Core.Events;

namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Контракт логики игры.
/// </summary>
public interface IGameEngine
{
    event EventHandler<GuessMadeEventArgs>? GuessMade;
    event EventHandler<GameOverEventArgs>? GameOver;

    /// <summary>
    /// Запускает новую игру.
    /// </summary>
    void StartNewGame();

    /// <summary>
    /// Обрабатывает очередную попытку игрока.
    /// </summary>
    void MakeGuess(int guess);
}