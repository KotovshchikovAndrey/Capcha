using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models;

public class PlayerAccount
{
    public string AccountName { get; private set; } = "Default Account Name";
    public decimal Balance { get; private set; } = 0;

    public void SetBalance(decimal balance)
    {
        if (balance < 0)
        {
            throw PlayerAccountException.NegativeValue("Баланс не может быть отрицательным!");
        }
        
        Balance = balance;
    }

    public void SetAccountName(string accountName)
    {
        if (accountName.Length is < 10 or > 100)
        {
            throw PlayerAccountException.InvalidAccountName(
                "Длина названия счета должна быть от 10 до 100 символов!");
        }
        
        AccountName = accountName;
    }
    
    public decimal IncreaseBalance(decimal amount)
    {
        if (amount < 0)
        {
            throw PlayerAccountException.NegativeValue("Сумма для начисления не может быть отрицательной!");
        }
        
        Balance += amount;
        return amount;
    }

    public decimal DecreaseBalance(decimal amount)
    {
        if (amount < 0)
        {
            throw PlayerAccountException.NegativeValue("Сумма для списания не может быть отрицательной!");
        }
        
        if (Balance < amount)
        {
            throw PlayerAccountException.InsufficientBalance("Недостаточно средств на балансе!");
        }
        
        Balance -= amount;
        return amount;
    }
}