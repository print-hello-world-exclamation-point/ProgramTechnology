using GuessNumber.Core.Interfaces;

namespace GuessNumber.Core.Services;

/// <summary>
/// Форматирует запись статистики в человекочитаемый текстовый формат.
/// </summary>
public class TextStatisticsFormatter : IStatisticsFormatter
{
    public string Format(DateTime timestamp, bool isWin, int attemptsUsed, string difficultyName)
    {
        string resultText = isWin ? "ПОБЕДА" : "ПОРАЖЕНИЕ";
        string date = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
        return $"[{date}] Уровень: {difficultyName} | Результат: {resultText} | Попыток: {attemptsUsed}";
    }
}