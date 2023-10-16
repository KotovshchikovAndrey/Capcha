using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackPlayer : BlackjackPlayer
{
    private readonly List<Card> _cards;

    public ClassicBlackjackPlayer(Player player, List<Card> initialCards) : base(player)
    {
        if (initialCards.Count != 2)
        {
            throw new Exception("Initial number of cards in classic blackjack must be 2!");
        }
        
        _cards = initialCards;
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