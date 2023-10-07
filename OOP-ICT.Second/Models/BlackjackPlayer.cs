using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BlackjackPlayer : Player
{
    public decimal CurrentBet { get; private set; } = 0;

    public BlackjackPlayer(Guid? uuid, string name, string surname) : base(uuid, name, surname) {}

    public void IncreaseCurrentBet(decimal betIncrease)
    {
        if (betIncrease < 0)
        {
            throw new Exception("Ставка не может быть отрицательной!");
        }

        CurrentBet += betIncrease;
    }
}