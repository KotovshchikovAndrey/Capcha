using OOP_ICT.Models;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackDealer : CasinoCardPlayer<IDealer>
{
    public ClassicBlackjackDealer(IDealer dealer) : base(dealer) {}

    public override void SetInitialCards(List<Card> cards)
    {
        if (cards.Count != Constants.InitialCardCountForDealer)
        {
            throw CardPlayerException.InvalidInitialCardCount("Initial card count must be 1!");
        }
        
        Cards = cards;
    }
}