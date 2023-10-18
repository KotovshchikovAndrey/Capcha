using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Abstractions;

public abstract class CasinoCardGame<TP, TD> 
    where TP : CasinoCardPlayer<Player>, ICanPlaceBet
    where TD : CasinoCardPlayer<IDealer> 
{
    protected readonly ICasinoBank CasinoBank;
    protected readonly Dictionary<Guid, TP> Players;
    protected readonly TD Dealer;
    
    public bool IsGameActive { get; protected set; } = false;

    protected CasinoCardGame(ICasinoBank casinoBank, Dictionary<Guid, TP> players, TD dealer)
    {
        CasinoBank = casinoBank ?? throw CardGameException.NullReference("Casino bank cannot be null!");
        Players = players ?? throw CardGameException.NullReference("Players dictionary cannot be null!");
        Dealer = dealer ?? throw CardGameException.NullReference("Dealer cannot be null!");
    }

    public abstract void StartGame();
    public abstract void FinishGame();
    public abstract void HandOutCards();
    public abstract void RemovePlayerFromGame(Guid playerUuid);
    public abstract void DealAdditionalCardForPlayer(Guid playerUuid);
    public abstract void IncreasePlayerBet(Guid playerUuid, decimal betIncrease);
    public abstract decimal AddWinningAmount(Guid playerUuid);
    public abstract decimal SubtractLossAmount(Guid playerUuid);
    public abstract IReadOnlyList<Card> GetDealerCards();
    public abstract IReadOnlyList<Card> GetPlayerCards(Guid playerUuid);
    public abstract decimal GetPlayerBet(Guid playerUuid);
}