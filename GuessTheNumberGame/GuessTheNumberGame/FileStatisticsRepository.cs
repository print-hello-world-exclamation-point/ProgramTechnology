using GuessNumber.Core.Interfaces;

namespace GuessNumber.Core.Services;

/// <summary>
/// Сохраняет статистику игр в текстовый файл.
/// </summary>
public class FileStatisticsRepository : IStatisticsRepository
{
    private readonly string _filePath;
    private readonly IStatisticsFormatter _formatter;

    public FileStatisticsRepository(string filePath, IStatisticsFormatter formatter)
    {
        _filePath = string.IsNullOrWhiteSpace(filePath)
            ? throw new ArgumentException("Путь к файлу не может быть пустым.", nameof(filePath))
            : filePath;
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public void Save(bool isWin, int attemptsUsed, string difficultyName)
    {
        string line = _formatter.Format(DateTime.Now, isWin, attemptsUsed, difficultyName);
        File.AppendAllText(_filePath, line + Environment.NewLine);
    }
}
