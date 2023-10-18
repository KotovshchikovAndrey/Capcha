using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Exceptions;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackPlayer : CasinoCardPlayer<Player>, ICanPlaceBet
{
    public decimal CurrentBet { get; private set; } = 0;
    
    public ClassicBlackjackPlayer(Player player) : base(player) {}
    
    public override void SetInitialCards(List<Card> cards)
    {
        if (cards.Count != 2)
        {
            throw CardPlayerException.InvalidInitialCardCount("Initial card count must be 2!");
        }

        Cards = cards;
    }

    public void IncreaseCurrentBet(decimal betIncrease)
    {
        if (betIncrease < 0)
        {
            throw PlayerException.NegativeValue("Bet cannot be negative value!");
        }

        CurrentBet += betIncrease;
    }
}