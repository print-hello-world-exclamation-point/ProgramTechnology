namespace GuessNumber.Core;

/// <summary>
/// Интерфейс для сохранения результатов игры.
/// </summary>
public interface IStatisticsService
{
    /// <summary>
    /// Сохраняет результат текущей игры.
    /// </summary>
    /// <param name="isWin">Победил ли игрок.</param>
    /// <param name="attempts">Количество затраченных попыток.</param>
    /// <param name="level">Уровень сложности.</param>
    void SaveResult(bool isWin, int attempts, Difficulty level);
}