using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models.CurrencyBetConverters;

public class EurBetConverter : CurrencyBetConverter
{
    public override decimal ConvertBetIntoCurrency(decimal bet)
    {
        return bet * Constants.BetPriceInUsd * (decimal)0.953927;
    }
}