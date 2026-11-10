using GuessNumber.Core;

namespace GuessNumber;

class Program
{
    static void Main(string[] args)
    {
        var settings = new GameSettings(Difficulty.Easy);
        var game = new GameEngine(settings);
        var ui = new ConsoleUI(game, settings);

        ui.Start();
    }
}