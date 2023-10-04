using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Second.Models.PlayerBills;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBaseBank
{
    private readonly IBank _bank = new BaseBank();
    private readonly PlayerBill _playerBill = new EurPlayerBill(1000);

    [Fact]
    public void TestIsAddBetToPlayerBillWorkCorrect_ReturnTrue()
    {
        const int bet = 100;
        var accruedAmount = _bank.AddBetToPlayerBill(_playerBill, bet);

        var currencyBetConverter = _playerBill.GetCurrencyBetConverter();
        var betIntoCurrency = currencyBetConverter.ConvertBetIntoCurrency(bet);
        
        Assert.Equal(betIntoCurrency, accruedAmount);
        Assert.Equal(_playerBill.Balance, 1000 + betIntoCurrency);
    }

    [Fact]
    public void TestIsSubtractBetFromPlayerBillWorkCorrect_ReturnTrue()
    {
        const int bet = 100;
        var amountSpent = _bank.SubtractBetFromPlayerBill(_playerBill, bet);

        var currencyBetConverter = _playerBill.GetCurrencyBetConverter();
        var betIntoCurrency = currencyBetConverter.ConvertBetIntoCurrency(bet);
        
        Assert.Equal(betIntoCurrency, amountSpent);
        Assert.Equal(_playerBill.Balance, 1000 - betIntoCurrency);
    }

    [Fact]
    public void TestIsCheckIsBalanceSufficientForBetWorkCorrect_ReturnTrue()
    {
        Assert.True(_bank.CheckIsBalanceSufficientForBet(_playerBill, 100));
        Assert.False(_bank.CheckIsBalanceSufficientForBet(_playerBill, 999999999));
    }
}