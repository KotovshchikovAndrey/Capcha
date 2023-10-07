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
    
    public string BuyChipsForPlayer(Guid playerUuid, decimal chipsCount)
    {
        // Снимаем деньги с денежного счета
        var chipsPrice = chipsCount * Constants.ChipPrice;
        var moneySpentAmount = _moneyBank.SubtractAmountFromPlayerBalance(playerUuid, chipsPrice);
        
        // Зачисляем фишки на счет казино
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.IncreaseBalance(chipsCount);

        return $"-{moneySpentAmount}";
    }

    public string SellChipsForRealMoney(Guid playerUuid, decimal chipsCount)
    {
        // Снимаем фишки со счета казино
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.DecreaseBalance(chipsCount);
        
        // Переводим фищки в деньги и зачисляем их на денежный счет
        var chipsPrice = chipsCount * Constants.ChipPrice;
        var moneyAccruedAmount = _moneyBank.AddAmountToPlayerBalance(playerUuid, chipsPrice);
        
        return $"+{moneyAccruedAmount}";
    }

    public decimal AddChipsToPlayerCasinoBalance(Guid playerUuid, decimal chipsCount)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.IncreaseBalance(chipsCount);
        return chipsCount;
    }

    public decimal SubtractChipsFromPlayerCasinoBalance(Guid playerUuid, decimal chipsCount)
    {
        var playerCasinoAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        playerCasinoAccount.DecreaseBalance(chipsCount);
        return chipsCount;
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
        playerAccountBuilder.SetAccountName($"Банк фишек игрока {player.Name} {player.Surname}");
        
        var newPlayerCasinoAccount = playerAccountBuilder.BuildPlayerAccount();
        _repository.SavePlayerAccount(player.Uuid, newPlayerCasinoAccount);
    }
}