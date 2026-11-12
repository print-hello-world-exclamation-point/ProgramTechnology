using GuessNumber.Core.Models;

namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Поставщик пользовательского ввода.
/// </summary>
public interface IUserInput
{
    /// <summary>
    /// Запрашивает у пользователя выбор одного из доступных уровней сложности.
    /// </summary>
    GameSettings SelectDifficulty(IReadOnlyList<GameSettings> availableDifficulties);

    /// <summary>
    /// Запрашивает у пользователя очередное число.
    /// </summary>
    int ReadGuess(int minValue, int maxValue);
}
