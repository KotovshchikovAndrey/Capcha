using OOP_ICT.Second.Enums;
using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models.PlayerBills;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestPlayerBill
{
    [Fact]
    public void TestEurPlayerBuildCurrency_ReturnTrue()
    {
        var playerBill = new EurPlayerBill();
        Assert.Equal(Currency.EUR, playerBill.Currency);
    } 
    
    [Fact]
    public void TestUsdPlayerBuildCurrency_ReturnTrue()
    {
        var playerBill = new UsdPlayerBill();
        Assert.Equal(Currency.USD, playerBill.Currency);
    } 
    
    [Fact]
    public void TestRubPlayerBuildCurrency_ReturnTrue()
    {
        var playerBill = new RubPlayerBill();
        Assert.Equal(Currency.RUB, playerBill.Currency);
    } 
    
    [Fact]
    public void TestThrowNegativeBalanceException_ReturnTrue()
    {
        var exception = Assert.Throws<PlayerBillException>(() => new UsdPlayerBill(balance: -100));
        Assert.Equal("Баланс не может быть отрицательным!", exception.Message);
    }

    [Fact]
    public void TestIsIncreaseBalanceWorkCorrect_ReturnTrue()
    {
        var playerBill = new UsdPlayerBill();
        playerBill.IncreaseBalance(amount: 100);
        Assert.Equal(100, playerBill.Balance);
    }

    [Fact]
    public void TestIsDecreaseBalanceWorkCorrect_ReturnTrue()
    {
        var playerBill = new UsdPlayerBill(balance: 100);
        playerBill.DecreaseBalance(50);
        
        var exception = Assert.Throws<PlayerBillException>(
            () => playerBill.DecreaseBalance(100));
        
        Assert.Equal("Недостаточно средств на балансе!", exception.Message);
        Assert.Equal(50, playerBill.Balance);

    }

    [Fact]
    public void TestThrowNegativeValueException_ReturnTrue()
    {
        var playerBill = new UsdPlayerBill();
        var increaseBalanceException = Assert.Throws<PlayerBillException>(
            () => playerBill.IncreaseBalance(-100));
        
        var decreaseBalanceException = Assert.Throws<PlayerBillException>(
            () => playerBill.DecreaseBalance(-100));
        
        Assert.Equal("Сумма для начисления не может быть отрицательной!", increaseBalanceException.Message);
        Assert.Equal("Сумма для списания не может быть отрицательной!", decreaseBalanceException.Message);
    }
}