using OOP_ICT.Models;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackDealer
{
    public IDealer Dealer { get; }
    private readonly List<Card> _cards;

    public ClassicBlackjackDealer(IDealer dealer, List<Card> initialCards)
    {
        if (initialCards.Count != 1)
        {
            throw new Exception("Initial cards count must be 1!");
        }
        
        Dealer = dealer ?? throw new Exception("Dealer cannot be null!");
        _cards = initialCards ?? throw new Exception("Initial Cards cannot be null!");
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
}