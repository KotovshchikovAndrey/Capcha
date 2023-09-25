namespace OOP_ICT.Models;

public abstract class CardDeck
{
    protected readonly List<Card> Cards;
    protected CardDeck(List<Card> cards)
    {
        Cards = cards;
    }
    
    public IReadOnlyList<Card> GetCardsInOriginalOrder()
    {
        return Cards.AsReadOnly();
    }

    public abstract IReadOnlyList<Card> ShuffleCards();
}