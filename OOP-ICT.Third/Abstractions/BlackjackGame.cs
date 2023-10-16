using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Abstractions;

public abstract class BlackjackGame
{
    protected readonly ICasinoManager CasinoManager;

    protected BlackjackGame(ICasinoManager casinoManager)
    {
        CasinoManager = casinoManager;
    }

    public abstract void StartGame(List<BlackjackPlayer> players);
    public abstract void FinishGame();
    public abstract void AddPlayerInGame(Player player, decimal initialBet);
    public abstract void RemovePlayerFromGame(Guid playerUuid);
    public abstract void DealAdditionalCardForPlayer(Guid playerUuid);
    public abstract void DealAdditionalCardForDealer();
    public abstract IReadOnlyList<Card> GetMyCards(Guid myUuid);
}