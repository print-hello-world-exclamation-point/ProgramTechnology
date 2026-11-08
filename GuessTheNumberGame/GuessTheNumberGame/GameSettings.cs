namespace GuessNumber.Core;

/// <summary>
/// Уровни сложности игры.
/// </summary>
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

/// <summary>
/// Настройки игры, зависящие от сложности.
/// </summary>
public class GameSettings
{
    /// <summary>Выбранный уровень сложности.</summary>
    public Difficulty Level { get; }

    /// <summary>Минимальное загадываемое число.</summary>
    public int MinValue { get; }

    /// <summary>Максимальное загадываемое число.</summary>
    public int MaxValue { get; }

    /// <summary>Максимальное количество попыток.</summary>
    public int MaxAttempts { get; }

    /// <summary>
    /// Инициализирует настройки в зависимости от выбранного уровня сложности.
    /// </summary>
    public GameSettings(Difficulty level)
    {
        Level = level;

        switch (level)
        {
            case Difficulty.Easy:
                MinValue = 1;
                MaxValue = 10;
                MaxAttempts = 5;
                break;
            case Difficulty.Medium:
                MinValue = 1;
                MaxValue = 50;
                MaxAttempts = 7;
                break;
            case Difficulty.Hard:
                MinValue = 1;
                MaxValue = 100;
                MaxAttempts = 10;
                break;
        }
    }
}