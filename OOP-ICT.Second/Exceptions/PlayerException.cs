namespace OOP_ICT.Second.Exceptions;

public class PlayerException : Exception
{
    private PlayerException(string message) : base(message) {}

    public static PlayerException NegativeValue(string message)
    {
        return new PlayerException(message);
    }
}