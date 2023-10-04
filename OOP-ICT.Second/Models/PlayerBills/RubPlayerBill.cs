using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Enums;
using OOP_ICT.Second.Models.CurrencyBetConverters;

namespace OOP_ICT.Second.Models.PlayerBills;

public class RubPlayerBill : PlayerBill
{
    public RubPlayerBill(decimal balance = 0) : base(Currency.RUB, balance) {}
    protected override CurrencyBetConverter CreateCurrencyBetConverter()
    {
        return new RubBetConverter();
    }
}