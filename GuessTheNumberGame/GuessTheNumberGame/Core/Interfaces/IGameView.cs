using GuessNumber.Core.Models;

namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Представление для отображения хода и результатов игры.
/// </summary>
public interface IGameView
{
    /// <summary>
    /// Отображает приветствие и правила текущей игры.
    /// </summary>
    void ShowWelcome(GameSettings settings);

    /// <summary>
    /// Отображает подсказку после очередной попытки.
    /// </summary>
    void ShowGuessFeedback(GuessResult result, int attemptsLeft);

    /// <summary>
    /// Отображает итоговый экран победы или поражения.
    /// </summary>
    void ShowGameOver(bool isWin, int secretNumber, int attemptsUsed);
}