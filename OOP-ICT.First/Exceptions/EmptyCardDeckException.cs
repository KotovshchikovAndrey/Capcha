namespace OOP_ICT.Exceptions;

public class EmptyCardDeckException : Exception
{
    public EmptyCardDeckException(string message) : base(message) {}
}