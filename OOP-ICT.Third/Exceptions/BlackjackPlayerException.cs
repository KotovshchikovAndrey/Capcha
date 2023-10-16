namespace OOP_ICT.Third.Exceptions;

public class BlackjackPlayerException : Exception
{
    private BlackjackPlayerException(string message) : base(message) {}
    
    public static BlackjackPlayerException NullReference(string message)
    {
        return new BlackjackPlayerException(message);
    }
    
    public static BlackjackPlayerException InvalidInitialCardCount(string message)
    {
        return new BlackjackPlayerException(message);
    }
}