namespace OOP_ICT.Models;

public class CardDeck : ICardDeck
{
    private readonly List<Card> _cards; 
    public CardDeck(List<Card> cards)
    {
        _cards = cards;
    }
    
    public IReadOnlyList<Card> UnpackCards()
    {
        return _cards.AsReadOnly();
    }
}