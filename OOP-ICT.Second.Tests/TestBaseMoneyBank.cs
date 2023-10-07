using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBaseMoneyBank
{
    private readonly MoneyBank _bank = new BaseMoneyBank(new PlayerAccountRepository());
    private readonly Player _player = new Player(null,"Test", "Player");

    public TestBaseMoneyBank()
    {
        _bank.CreateNewAccountForPlayer(_player);
    }

    [Fact]
    public void TestIsAddAmountToPlayerBalanceWorkCorrect_ReturnTrue()
    {
        var accruedAmount = _bank.AddAmountToPlayerBalance(_player.Uuid, 100);
        var playerAccountInfo = _bank.GetPlayerAccountInfo(_player.Uuid);
        
        Assert.Equal(100, playerAccountInfo.Balance);
        Assert.Equal(100, accruedAmount);
    }

    [Fact]
    public void TestIsSubtractAmountFromPlayerBalanceWorkCorrect_ReturnTrue()
    {
        _bank.AddAmountToPlayerBalance(_player.Uuid, 100);
        var amountSpent = _bank.SubtractAmountFromPlayerBalance(_player.Uuid, 100);
        
        var playerAccountInfo = _bank.GetPlayerAccountInfo(_player.Uuid);
        Assert.Equal(100, amountSpent);
        Assert.Equal(0, playerAccountInfo.Balance);
    }
}