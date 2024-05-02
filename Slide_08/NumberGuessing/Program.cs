namespace  NumberGuessing;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Number guessing game ===");
        int min = ReadIntFromConsole("Lowest number");
        int max = ReadIntFromConsole("Highest number");

        GuessNumberGame game = new GuessNumberGame(min, max);
        game.GuessedRight += GameOnGuessedRight;

        while (true)
        {
            int numberOfPlayers = ReadIntFromConsole("Number of players");
            game.Start(numberOfPlayers);

            while (true)
            {
                Console.WriteLine($"Player {game.CurrentPlayer} turn");
                int guess = ReadIntFromConsole("Guess");
                NumberGuessStatus guessResult = game.Guess(guess);

                if (guessResult == NumberGuessStatus.GuessedRight)
                {
                    Console.WriteLine($"Player {game.CurrentPlayer} won");
                    break;
                }
                
                Console.WriteLine($"The guess was too {(guessResult == NumberGuessStatus.HigherThanGuessedNumber ? "low" : "high")}.");
            }
            
            Console.Write("Quit game? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
                break;
        }
    }

    private static void GameOnGuessedRight(object? sender, GuessedRightEventArgs e)
    {
        Console.WriteLine($"Event GameOnGuessedRight: Attempts: {e.Attempts}, Winner: {e.Winner}");
    }

    public static int ReadIntFromConsole(string name)
    {
        while (true)
        {
            Console.Write($"{name}: ");

            if (int.TryParse(Console.ReadLine(), out int value))
                return value;
            
            Console.WriteLine("Please enter a number!");
        }
    }
}

