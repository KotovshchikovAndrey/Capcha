using OOP_ICT.Second.Models;

namespace OOP_ICT.Second.Abstractions;

public interface ICasinoBank
{
    public void BuyChipsForPlayer(Guid playerUuid, decimal chipsCount);
    public void SellChipsForRealMoney(Guid playerUuid, decimal chipsCount);
    public void AddChipsToPlayerCasinoBalance(Guid playerUuid, decimal chipsCount);
    public void SubtractChipsFromPlayerCasinoBalance(Guid playerUuid, decimal chipsCount);
    public bool CheckIsPlayerCasinoBalanceSufficient(Guid playerUuid, decimal chipsCount);
    public PlayerAccountInfo GetPlayerCasinoAccountInfo(Guid playerUuid);
    public void CreateNewCasinoAccountForPlayer(Player player);
}