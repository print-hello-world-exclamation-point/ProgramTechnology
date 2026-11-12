using GuessNumber.Core.Models;

namespace GuessNumber.Core.Events;

/// <summary>
/// Данные события, возникающего после проверки числа игрока.
/// </summary>
public class GuessMadeEventArgs : EventArgs
{
    /// <summary>Результат проверки введенного числа.</summary>
    public GuessResult Result { get; }

    /// <summary>Количество оставшихся попыток.</summary>
    public int AttemptsLeft { get; }

    public GuessMadeEventArgs(GuessResult result, int attemptsLeft)
    {
        Result = result;
        AttemptsLeft = attemptsLeft;
    }
}
