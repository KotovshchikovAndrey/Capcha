using OOP_ICT.Second.Models;

namespace OOP_ICT.Second.Abstractions;

public interface ICasinoBank
{
    public string BuyChipsForPlayer(Guid playerUuid, decimal chipsCount);
    public string SellChipsForRealMoney(Guid playerUuid, decimal chipsCount);
    public decimal AddChipsToPlayerCasinoBalance(Guid playerUuid, decimal chipsCount);
    public decimal SubtractChipsFromPlayerCasinoBalance(Guid playerUuid, decimal chipsCount);
    public bool CheckIsPlayerCasinoBalanceSufficient(Guid playerUuid, decimal chipsCount);
    public PlayerAccountInfo GetPlayerCasinoAccountInfo(Guid playerUuid);
    public void CreateNewCasinoAccountForPlayer(Player player);
}