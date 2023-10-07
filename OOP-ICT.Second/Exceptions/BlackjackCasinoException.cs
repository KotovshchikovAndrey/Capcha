namespace OOP_ICT.Second.Exceptions;

public class BlackjackCasinoException : Exception
{
    private BlackjackCasinoException(string message) : base(message) {}

    public static BlackjackCasinoException PlayerDoesNotExists(string message)
    {
        return new BlackjackCasinoException(message);
    }

    public static BlackjackCasinoException BalanceIsNotSufficientForBet(string message)
    {
        return new BlackjackCasinoException(message);
    }
}