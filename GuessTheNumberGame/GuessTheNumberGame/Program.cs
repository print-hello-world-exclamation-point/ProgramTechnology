using GuessNumber.ConsoleApp;
using GuessNumber.Core.Interfaces;
using GuessNumber.Core.Models;
using GuessNumber.Core.Services;

namespace GuessNumber;

class Program
{
    static void Main(string[] args)
    {
        IUserInput userInput = new ConsoleUserInput();
        IGameView gameView = new ConsoleGameView();

        IDifficultyProvider difficultyProvider = new DefaultDifficultyProvider();
        GameSettings selectedSettings = userInput.SelectDifficulty(difficultyProvider.GetAvailableDifficulties());

        IRandomGenerator randomGenerator = new SystemRandomGenerator();
        IGameEngine gameEngine = new GameEngine(selectedSettings, randomGenerator);

        IStatisticsFormatter formatter = new TextStatisticsFormatter();
        IStatisticsRepository statsRepository = new FileStatisticsRepository("stats.txt", formatter);

        try
        {
            using var statsSubscriber = new StatisticsEventSubscriber(gameEngine, statsRepository);
            using var sessionController = new GameSessionController(gameEngine, userInput, gameView, selectedSettings);

            sessionController.Run();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при работе с файлом статистики: {ex.Message}");
        }
    }
}
