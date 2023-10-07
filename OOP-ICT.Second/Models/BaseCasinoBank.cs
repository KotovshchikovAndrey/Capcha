using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BaseCasinoBank : ICasinoBank
{
    private readonly IPlayerAccountRepository _repository;
    private readonly MoneyBank _moneyBank;
    
    public BaseCasinoBank(IPlayerAccountRepository repository, MoneyBank moneyBank)
    {
        _repository = repository;
        _moneyBank = moneyBank;
    }
    
    public void BuyChipsForPlayer(Guid playerUuid, decimal chipsCount)
    {
        // Снимаем деньги с денежного счета
        var chipsPrice = chipsCount * Constants.ChipPrice;
        _moneyBank.SubtractAmountFromPlayerBalance(playerUuid, chipsPrice);
        
        // Зачисляем фишки на счет казино
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.IncreaseBalance(chipsCount);
    }

    public void SellChipsForRealMoney(Guid playerUuid, decimal chipsCount)
    {
        // Снимаем фишки со счета казино
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.DecreaseBalance(chipsCount);
        
        // Переводим фищки в деньги и зачисляем их на денежный счет
        var chipsPrice = chipsCount * Constants.ChipPrice;
        _moneyBank.AddAmountToPlayerBalance(playerUuid, chipsPrice);
    }

    public void AddChipsToPlayerCasinoBalance(Guid playerUuid, decimal chipsCount)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.IncreaseBalance(chipsCount);
    }

    public void SubtractChipsFromPlayerCasinoBalance(Guid playerUuid, decimal chipsCount)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.DecreaseBalance(chipsCount);
    }

    public bool CheckIsPlayerCasinoBalanceSufficient(Guid playerUuid, decimal chipsCount)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        return playerCasinoAccount.Balance >= chipsCount;
    }

    public PlayerAccountInfo GetPlayerCasinoAccountInfo(Guid playerUuid)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        return new PlayerAccountInfo(playerCasinoAccount.AccountName, playerCasinoAccount.Balance);
    }

    public void CreateNewCasinoAccountForPlayer(Player player)
    {
        var playerAccountBuilder = new PlayerAccountBuilder();
        playerAccountBuilder.SetBalance(0);
        playerAccountBuilder.SetAccountName($"Player`s bank of chips {player.Name} {player.Surname}");
        
        var newPlayerCasinoAccount = playerAccountBuilder.BuildPlayerAccount();
        _repository.SavePlayerAccount(player.Uuid, newPlayerCasinoAccount);
    }
}