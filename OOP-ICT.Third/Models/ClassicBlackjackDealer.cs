using OOP_ICT.Models;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackDealer
{
    public IDealer Dealer { get; }
    private readonly List<Card> _cards;

    public ClassicBlackjackDealer(IDealer dealer, List<Card> initialCards)
    {
        if (initialCards.Count != 1)
        {
            throw DealerException.InvalidInitialCardCount("Initial cards count must be 1!");
        }
        
        Dealer = dealer ?? throw DealerException.NullReference("Dealer cannot be null!");
        _cards = initialCards ?? throw DealerException.NullReference("Initial Cards cannot be null!");
    }

    public void AddCard(Card card)
    {
        if (card is null) throw DealerException.NullReference("Card cannot be null!");
        _cards.Add(card);
    }

    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
}