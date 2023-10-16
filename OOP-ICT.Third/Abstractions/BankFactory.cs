using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Third.Abstractions;

public abstract class BankFactory
{
    public abstract MoneyBank CreateMoneyBank();
    public abstract ICasinoBank CreateCasinoBank(MoneyBank moneyBank);
}