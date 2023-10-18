using OOP_ICT.Models;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Models;

public class ClassicBlackjackDealer : CasinoCardPlayer<IDealer>
{
    // public IDealer DealerInstance { get; }

    public ClassicBlackjackDealer(IDealer dealer) : base(dealer) {}
    // {
    //     DealerInstance = dealer ?? throw CardPlayerException.NullReference("Dealer instance cannot be null!");;
    // }

    public override void SetInitialCards(List<Card> cards)
    {
        if (cards.Count != 1)
        {
            throw CardPlayerException.InvalidInitialCardCount("Initial card count must be 1!");
        }
        
        Cards = cards;
    }
}