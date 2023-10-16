namespace OOP_ICT.Third.Exceptions;

public class CasinoManagerException : Exception
{
    private CasinoManagerException(string message) : base(message) {}
    
    public static CasinoManagerException NullReference(string message)
    {
        return new CasinoManagerException(message);
    }
    
    public static CasinoManagerException BalanceIsNotSufficientForBet(string message)
    {
        return new CasinoManagerException(message);
    }
    
    public static CasinoManagerException PlayerDoesNotExists(string message)
    {
        return new CasinoManagerException(message);
    }
    
    public static CasinoManagerException PlayerAlreadyExists(string message)
    {
        return new CasinoManagerException(message);
    }
}