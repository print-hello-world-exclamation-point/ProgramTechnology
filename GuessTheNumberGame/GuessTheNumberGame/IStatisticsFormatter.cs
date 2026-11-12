namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Форматирует данные о завершенной игре в текстовую запись.
/// </summary>
public interface IStatisticsFormatter
{
    string Format(DateTime timestamp, bool isWin, int attemptsUsed, string difficultyName);
}
