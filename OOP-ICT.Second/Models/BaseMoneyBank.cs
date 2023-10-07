using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BaseMoneyBank : MoneyBank
{
    public BaseMoneyBank(IPlayerAccountRepository repository) : base(repository) {}

    protected override PlayerAccount CreatePlayerAccount(Player player)
    {
        var playerAccountBuilder = new PlayerAccountBuilder();
        playerAccountBuilder.SetBalance(0);
        playerAccountBuilder.SetAccountName($"Денежный счет игрока {player.Name} {player.Surname}");
        
        return playerAccountBuilder.BuildPlayerAccount();
    }
}