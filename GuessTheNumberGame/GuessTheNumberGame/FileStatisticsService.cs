namespace GuessNumber.Core;

/// <summary>
/// Сервис для сохранения статистики в текстовый файл.
/// </summary>
public class FileStatisticsService : IStatisticsService
{
    private readonly string _filePath;

    /// <summary>
    /// Инициализирует сервис с указанием пути к файлу.
    /// </summary>
    /// <param name="filePath">Путь к файлу статистики. По умолчанию "stats.txt".</param>
    public FileStatisticsService(string filePath = "stats.txt")
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Дописывает результат игры в конец файла.
    /// </summary>
    public void SaveResult(bool isWin, int attempts, Difficulty level)
    {
        string resultText = isWin ? "ПОБЕДА" : "ПОРАЖЕНИЕ";
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        string line = $"[{date}] Уровень: {level} | Результат: {resultText} | Попыток: {attempts}{Environment.NewLine}";

        try
        {
            File.AppendAllText(_filePath, line);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении статистики: {ex.Message}");
        }
    }
}