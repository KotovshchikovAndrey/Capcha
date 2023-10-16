using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Third.Abstractions;

public interface ICasinoManager
{
    void AddPlayerInGame(Player player);
    void RemovePlayerFromGame(Guid playerUuid);
    void AddChipsToPlayerBalance(Guid playerUuid, decimal amount);
    void SubtractChipsFromPlayerBalance(Guid playerUuid, decimal amount);
    void IncreasePlayerBet(Guid playerUuid, decimal bet);
    void DealCardForPlayer(Guid playerUuid);
    void DealCardForDealer();
    IReadOnlyList<Card> GetPlayerCards(Guid playerUuid);
    IReadOnlyList<Card> GetDealerCards();
    decimal GetPLayerBet(Guid playerUuid);
}