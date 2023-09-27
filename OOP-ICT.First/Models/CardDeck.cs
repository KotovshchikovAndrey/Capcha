namespace OOP_ICT.Models;

public class CardDeck
{
    public int Count => _cards.Count;
    private readonly List<Card> _cards; 
    public CardDeck(List<Card> cards)
    {
        _cards = cards;
    }

    public Card PopNextCard()
    {
        if (_cards.Count == 0)
        {
            throw new Exception("Колода пуста");
        }

        var card = _cards[0];
        _cards.RemoveAt(0);
        
        return card;
    }
    
    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
}