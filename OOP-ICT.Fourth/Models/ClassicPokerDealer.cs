using OOP_ICT.Models;
using OOP_ICT.Third.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Fourth.Models;

public class ClassicPokerDealer : CasinoCardPlayer<IDealer>
{
    private ClassicPokerPlayer _playerInstance;
    public ClassicPokerPlayer PlayerInstance
    {
        get => _playerInstance?? throw CardPlayerException.NullReference("Player instance has not been set!");
        set => _playerInstance = value ?? throw CardPlayerException.NullReference("Player instance cannot be null!");
    }

    public ClassicPokerDealer(IDealer dealerInstance) : base(dealerInstance) {}

    public override void SetInitialCards(List<Card> cards)
    {
        if (_playerInstance is null)
        {
            throw CardPlayerException.NullReference("Player instance has not been set!");
        }

        _playerInstance.SetInitialCards(cards);
    }
}