namespace GuessNumber.Core.Models;

/// <summary>
/// Параметры игровой сессии.
/// </summary>
/// <param name="DifficultyName">Название уровня сложности.</param>
/// <param name="MinValue">Минимальное загадываемое число.</param>
/// <param name="MaxValue">Максимальное загадываемое число.</param>
/// <param name="MaxAttempts">Максимальное количество попыток.</param>
public record GameSettings(string DifficultyName, int MinValue, int MaxValue, int MaxAttempts);