using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Fourth.Models;

public class ClassicPokerPlayer : CasinoCardPlayer<Player>, ICanPlaceBet
{
    public decimal CurrentBet { get; private set; } = 0;
    public ClassicPokerPlayer(Player modelInstance) : base(modelInstance) {}

    public void IncreaseCurrentBet(decimal betIncrease)
    {
        if (betIncrease < 0)
        {
            throw CardPlayerException.NegativeValue("Bet cannot be negative value!");
        }

        CurrentBet += betIncrease;
    }
    
    public override void SetInitialCards(List<Card> cards)
    {
        if (cards.Count != Constants.InitialCardCountForPlayer)
        {
            throw CardPlayerException.InvalidInitialCardCount($"Initial card count must be {Constants.InitialCardCountForPlayer}!");
        }

        Cards = cards;
    }

    public void RemoveCard(Card card)
    {
        var playerCard = Cards.Find(
            playerCard => (playerCard.Suit == card.Suit) 
                          && (playerCard.Value == card.Value));
        
        if (playerCard is not null)
        {
            Cards.Remove(card);
        }
    }
}
