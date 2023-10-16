using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.Models;

public class BaseBankFactory : BankFactory
{
    public override MoneyBank CreateMoneyBank()
    {
        var repository = new PlayerAccountRepository();
        return new BaseMoneyBank(repository);
    }

    public override ICasinoBank CreateCasinoBank(MoneyBank moneyBank)
    {
        var repository = new PlayerAccountRepository();
        return new BaseCasinoBank(repository, moneyBank);
    }
}