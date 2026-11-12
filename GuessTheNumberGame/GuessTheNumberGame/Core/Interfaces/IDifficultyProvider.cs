using GuessNumber.Core.Models;

namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Поставщик доступных уровней сложности.
/// </summary>
public interface IDifficultyProvider
{
    /// <summary>
    /// Возвращает список всех доступных конфигураций сложности.
    /// </summary>
    IReadOnlyList<GameSettings> GetAvailableDifficulties();
}