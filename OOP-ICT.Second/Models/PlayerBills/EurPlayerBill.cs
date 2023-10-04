using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Enums;
using OOP_ICT.Second.Models.CurrencyBetConverters;

namespace OOP_ICT.Second.Models.PlayerBills;

public class EurPlayerBill : PlayerBill
{
    public EurPlayerBill(decimal balance = 0) : base(Currency.EUR, balance) {}

    protected override CurrencyBetConverter CreateCurrencyBetConverter()
    {
        return new EurBetConverter();
    }
}