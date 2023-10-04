using OOP_ICT.Second.Enums;
using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Abstractions;

public abstract class PlayerBill
{
    public Currency Currency { get; }
    public decimal Balance { get; private set; }
    private CurrencyBetConverter CurrencyBetConverter => CreateCurrencyBetConverter();

    protected PlayerBill(Currency currency, decimal balance)
    {
        if (balance < 0)
        {
            throw PlayerBillException.NegativeValue("Баланс не может быть отрицательным!");
        }
        
        Balance = balance;
        Currency = currency;
    }
    
    public decimal IncreaseBalance(decimal amount)
    {
        if (amount < 0)
        {
            throw PlayerBillException.NegativeValue("Сумма для начисления не может быть отрицательной!");
        }
        
        Balance += amount;
        return amount;
    }

    public decimal DecreaseBalance(decimal amount)
    {
        if (amount < 0)
        {
            throw PlayerBillException.NegativeValue("Сумма для списания не может быть отрицательной!");
        }
        
        if (Balance < amount)
        {
            throw PlayerBillException.InsufficientBalance("Недостаточно средств на балансе!");
        }
        
        Balance -= amount;
        return amount;
    }

    public CurrencyBetConverter GetCurrencyBetConverter()
    {
        return CurrencyBetConverter;
    }
    
    protected abstract CurrencyBetConverter CreateCurrencyBetConverter();
}