using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BaseBank : IBank
{
    public decimal AddBetToPlayerBill(PlayerBill playerBill, decimal bet)
    {
        var currencyBetConverter = playerBill.GetCurrencyBetConverter();
        var betIntoCurrency = currencyBetConverter.ConvertBetIntoCurrency(bet);
        var amount = playerBill.IncreaseBalance(betIntoCurrency);
        
        return amount;
    }
    
    public decimal SubtractBetFromPlayerBill(PlayerBill playerBill, decimal bet)
    {
        var currencyBetConverter = playerBill.GetCurrencyBetConverter();
        var betIntoCurrency = currencyBetConverter.ConvertBetIntoCurrency(bet);
        var amount = playerBill.DecreaseBalance(betIntoCurrency);
        
        return amount;
    }

    public bool CheckIsBalanceSufficientForBet(PlayerBill playerBill, decimal bet)
    {
        var playerBalance = playerBill.Balance;
        var currencyBetConverter = playerBill.GetCurrencyBetConverter();
        var isBalanceSufficientForBet = currencyBetConverter.ConvertBetIntoCurrency(bet) <= playerBalance;
        
        return isBalanceSufficientForBet;
    }
}