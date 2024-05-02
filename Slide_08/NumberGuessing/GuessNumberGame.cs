namespace NumberGuessing;

public class GuessNumberGame : GuessGame
{
    private int _attempts = 0;
    private int _randomNumber;
    private int _numOfPlayers;

    public int Min { get; }
    
    public int Max { get; }

    public int CurrentPlayer { get; private set; }

    public bool IsFinished { get; private set; }

    public event EventHandler<GuessedRightEventArgs> GuessedRight; 

    public GuessNumberGame(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public void Start(int numOfPlayers)
    {
        if (numOfPlayers <= 0)
        {
            throw new ArgumentException("Must be greater than 0", nameof(numOfPlayers));
        }

        _numOfPlayers = numOfPlayers;
        IsFinished = false;
        CurrentPlayer = 1;
        _randomNumber = _random.Next(Min, Max + 1);
    }

    public NumberGuessStatus Guess(int number)
    {
        if (number == _randomNumber)
        {
            IsFinished = true;
            OnGuessedRight(new GuessedRightEventArgs(_attempts, CurrentPlayer));
            return NumberGuessStatus.GuessedRight;
        }

        CurrentPlayer++;

        if (CurrentPlayer > _numOfPlayers)
            CurrentPlayer = 1;
        
        return number > _randomNumber
            ? NumberGuessStatus.LowerThanGuessedNumber
            : NumberGuessStatus.HigherThanGuessedNumber;
    }

    protected virtual void OnGuessedRight(GuessedRightEventArgs args)
    {
        GuessedRight?.Invoke(this, args);
    }
}