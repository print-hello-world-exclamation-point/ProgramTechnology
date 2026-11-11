using GuessNumber.Core;

namespace GuessNumber;

class Program
{
    static void Main(string[] args)
    {
        var inputHandler = new UserInputHandler();
        Difficulty level = inputHandler.AskDifficulty();
        var settings = new GameSettings(level);

        var game = new GameEngine(settings);
        var stats = new FileStatisticsService("stats.txt");

        var ui = new ConsoleUI(game, settings, stats);
        ui.Start();
    }
}