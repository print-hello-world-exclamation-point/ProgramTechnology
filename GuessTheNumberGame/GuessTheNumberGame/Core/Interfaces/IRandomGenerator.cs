namespace GuessNumber.Core.Interfaces;

/// <summary>
/// Поставщик случайных чисел.
/// </summary>
public interface IRandomGenerator
{
    /// <summary>
    /// Возвращает случайное целое число в заданном диапазоне (включительно).
    /// </summary>
    int Next(int minValue, int maxValue);
}
