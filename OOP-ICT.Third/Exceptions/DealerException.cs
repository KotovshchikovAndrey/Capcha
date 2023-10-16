namespace OOP_ICT.Third.Exceptions;

public class DealerException : Exception
{
    private DealerException(string message) : base(message) {}
    
    public static DealerException NullReference(string message)
    {
        return new DealerException(message);
    }

    public static DealerException InvalidInitialCardCount(string message)
    {
        return new DealerException(message);
    }
}