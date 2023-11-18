namespace OOP_ICT.Fourth.Exceptions;

public class ClassicPokerException : Exception
{
    private ClassicPokerException(string message) : base(message) {}
    
    public static ClassicPokerException LastCircleIsOver(string message)
    {
        return new ClassicPokerException(message);
    }

    public static ClassicPokerException InsufficientStartBet(string message)
    {
        return new ClassicPokerException(message);
    }
}