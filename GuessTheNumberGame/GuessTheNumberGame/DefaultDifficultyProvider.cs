using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;

namespace GuessNumber.Core.Services;

/// <summary>
/// Предоставляет стандартный набор из трех уровней сложности.
/// </summary>
public class DefaultDifficultyProvider : IDifficultyProvider
{
    public IReadOnlyList<GameSettings> GetAvailableDifficulties()
    {
        return new List<GameSettings>
        {
            new("Легкий", 1, 10, 5),
            new("Средний", 1, 50, 7),
            new("Сложный", 1, 100, 10)
        };
    }
}
