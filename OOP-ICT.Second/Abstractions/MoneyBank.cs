using OOP_ICT.Second.Models;

namespace OOP_ICT.Second.Abstractions;

public abstract class MoneyBank
{
    private readonly IPlayerAccountRepository _repository;
    
    protected MoneyBank(IPlayerAccountRepository repository)
    {
        _repository = repository;
    }
    
    public decimal AddAmountToPlayerBalance(Guid playerUuid, decimal amount)
    {
        var playerAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        return playerAccount.IncreaseBalance(amount);
    }
    
    public decimal SubtractAmountFromPlayerBalance(Guid playerUuid, decimal amount)
    {
        var playerAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        return playerAccount.DecreaseBalance(amount);
    }

    public void CreateNewAccountForPlayer(Player player)
    {
        var newPlayerAccount = CreatePlayerAccount(player);
        _repository.SavePlayerAccount(player.Uuid, newPlayerAccount);
    }

    public PlayerAccountInfo GetPlayerAccountInfo(Guid playerUuid)
    {
        var playerAccount = _repository.FindPlayerAccountByPlayerUuid(playerUuid);
        return new PlayerAccountInfo(playerAccount.AccountName, playerAccount.Balance);
    }

    protected abstract PlayerAccount CreatePlayerAccount(Player player);
}