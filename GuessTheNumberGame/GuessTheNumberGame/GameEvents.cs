namespace GuessNumber.Core;

/// <summary>
/// Данные, передаваемые при каждой попытке угадать число.
/// </summary>
public class GuessEventArgs : EventArgs
{
    /// <summary>Введенное пользователем число.</summary>
    public int UserGuess { get; }

    /// <summary>Подсказка.</summary>
    public string Hint { get; }

    /// <summary>Сколько попыток осталось.</summary>
    public int AttemptsLeft { get; }

    public GuessEventArgs(int userGuess, string hint, int attemptsLeft)
    {
        UserGuess = userGuess;
        Hint = hint;
        AttemptsLeft = attemptsLeft;
    }
}

/// <summary>
/// Данные, передаваемые при окончании игры.
/// </summary>
public class GameOverEventArgs : EventArgs
{
    /// <summary>Победил ли игрок.</summary>
    public bool IsWin { get; }

    /// <summary>Загаданное число.</summary>
    public int SecretNumber { get; }

    public GameOverEventArgs(bool isWin, int secretNumber)
    {
        IsWin = isWin;
        SecretNumber = secretNumber;
    }
}