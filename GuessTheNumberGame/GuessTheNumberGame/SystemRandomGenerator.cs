using GuessNumber.Core.Interfaces;

namespace GuessNumber.Core.Services;

/// <summary>
/// Реализация генератора случайных чисел на базе System.Random.
/// </summary>
public class SystemRandomGenerator : IRandomGenerator
{
    private readonly Random _random = new();

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue + 1);
    }
}
