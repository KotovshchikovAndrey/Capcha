using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Enums;
using OOP_ICT.Second.Models.CurrencyBetConverters;

namespace OOP_ICT.Second.Models.PlayerBills;

public class UsdPlayerBill : PlayerBill
{
    public UsdPlayerBill(decimal balance = 0) : base(Currency.USD, balance) {}

    protected override CurrencyBetConverter CreateCurrencyBetConverter()
    {
        return new UsdBetConverter();
    }
}