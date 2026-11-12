namespace GuessNumber.Core.Events;

/// <summary>
/// Данные события, возникающего при завершении игры.
/// </summary>
public class GameOverEventArgs : EventArgs
{
    /// <summary>Победил ли игрок.</summary>
    public bool IsWin { get; }

    /// <summary>Загаданное число.</summary>
    public int SecretNumber { get; }

    /// <summary>Количество затраченных попыток.</summary>
    public int AttemptsUsed { get; }

    /// <summary>Название уровня сложности.</summary>
    public string DifficultyName { get; }

    public GameOverEventArgs(bool isWin, int secretNumber, int attemptsUsed, string difficultyName)
    {
        IsWin = isWin;
        SecretNumber = secretNumber;
        AttemptsUsed = attemptsUsed;
        DifficultyName = difficultyName;
    }
}