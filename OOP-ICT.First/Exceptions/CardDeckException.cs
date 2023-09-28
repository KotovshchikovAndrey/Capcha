namespace OOP_ICT.Exceptions;

public class CardDeckException : Exception
{
    private CardDeckException(string message) : base(message) {}

    public static CardDeckException EmptyCardDeck(string message)
    {
        return new CardDeckException(message);
    }
}