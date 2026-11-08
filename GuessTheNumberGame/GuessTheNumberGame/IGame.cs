namespace GuessNumber.Core;

/// <summary>
/// Основной интерфейс игры.
/// </summary>
public interface IGame
{
    /// <summary>Событие, вызываемое после каждой неудачной попытки.</summary>
    event EventHandler<GuessEventArgs> OnGuessMade;  

    /// <summary>Событие, вызываемое при победе или поражении.</summary>
    event EventHandler<GameOverEventArgs> OnGameOver; 

    /// <summary>
    /// Начинает новую игру.
    /// </summary>
    void StartNewGame();

    /// <summary>
    /// Совершает попытку угадать число.
    /// </summary>
    /// <param name="guess">Введенное число.</param>
    void MakeGuess(int guess);
}      