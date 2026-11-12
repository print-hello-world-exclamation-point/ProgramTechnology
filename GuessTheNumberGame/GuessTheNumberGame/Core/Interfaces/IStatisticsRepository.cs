namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Хранилище для сохранения результатов игр.
/// </summary>
public interface IStatisticsRepository
{
    /// <summary>
    /// Сохраняет запись об оконченной игре.
    /// </summary>
    void Save(bool isWin, int attemptsUsed, string difficultyName);
}