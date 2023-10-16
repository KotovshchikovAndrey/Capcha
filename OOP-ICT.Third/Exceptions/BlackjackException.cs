namespace OOP_ICT.Third.Exceptions;

public class BlackjackException : Exception
{
    private BlackjackException(string message) : base(message) {}

    public static BlackjackException NullReference(string message)
    {
        return new BlackjackException(message);
    }
    
    public static BlackjackException NotEnoughPlayersForStart(string message)
    {
        return new BlackjackException(message);
    }
}