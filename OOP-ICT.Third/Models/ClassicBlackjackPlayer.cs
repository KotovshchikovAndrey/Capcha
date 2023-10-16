using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackPlayer : BlackjackPlayer
{
    private readonly List<Card> _cards;

    public ClassicBlackjackPlayer(Player player, List<Card> initialCards) : base(player)
    {
        if (initialCards.Count != 2)
        {
            throw BlackjackPlayerException.InvalidInitialCardCount(
                "Initial number of cards in classic blackjack must be 2!");
        }
        
        _cards = initialCards;
    }

    public void AddCard(Card card)
    {
        if (card is null) throw BlackjackPlayerException.NullReference("Card cannot be null!");
        _cards.Add(card);
    }

    public IReadOnlyList<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }
}