using OOP_ICT.Models;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Fourth.Models;

public class ClassicPokerDealer : CasinoCardPlayer<IDealer>
{
    public ClassicPokerPlayer PlayerInstance
    {
        get => PlayerInstance ?? throw CardPlayerException.NullReference("Player instance has not been set!");
        set => PlayerInstance = value ?? throw CardPlayerException.NullReference("Player instance cannot be null!");
    }

    public ClassicPokerDealer(
        IDealer dealerInstance) : base(dealerInstance) {}

    public override void SetInitialCards(List<Card> cards)
    {
        if (PlayerInstance is null)
        {
            throw CardPlayerException.NullReference("Player instance has not been set!");
        }

        PlayerInstance.SetInitialCards(cards);
    }
}