using GuessNumber.Core.Events;

namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Контракт логики игры "Угадай число".
/// </summary>
public interface IGameEngine
{
    event EventHandler<GuessMadeEventArgs>? GuessMade;
    event EventHandler<GameOverEventArgs>? GameOver;

    /// <summary>
    /// Запускает новую игру (загадывает число и сбрасывает счетчик попыток).
    /// </summary>
    void StartNewGame();

    /// <summary>
    /// Обрабатывает очередную попытку игрока.
    /// </summary>
    void MakeGuess(int guess);
}
