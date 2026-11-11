namespace GuessNumber.Core;

public interface IGame
{
    event EventHandler<GuessEventArgs>? OnGuessMade;
    event EventHandler<GameOverEventArgs>? OnGameOver;

    /// <summary>Текущее количество оставшихся попыток.</summary>
    int AttemptsLeft { get; }

    void StartNewGame();
    void MakeGuess(int guess);
}