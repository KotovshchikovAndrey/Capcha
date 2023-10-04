namespace OOP_ICT.Second.Exceptions;

public class PlayerBillException : Exception
{
    private PlayerBillException(string message) : base(message) {}

    public static PlayerBillException NegativeValue(string message)
    {
        return new PlayerBillException(message);
    }

    public static PlayerBillException InsufficientBalance(string message)
    {
        return new PlayerBillException(message);
    }
}