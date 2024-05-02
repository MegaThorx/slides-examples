namespace NumberGuessing;

public class GuessedRightEventArgs : EventArgs
{
    public int Attempts { get; }

    public int Winner { get; } // The UML shows it as a string, but we only got a number?

    public GuessedRightEventArgs(int attempts, int winner)
    {
        Attempts = attempts;
        Winner = winner;
    }
}