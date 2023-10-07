using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models;

public class BlackjackPlayer : Player
{
    public decimal CurrentBet { get; private set; } = 0;

    public BlackjackPlayer(Guid uuid, string name, string surname) : base(uuid, name, surname) {}
    
    public BlackjackPlayer(string name, string surname) : base(name, surname) {}
    
    public void IncreaseCurrentBet(decimal betIncrease)
    {
        if (betIncrease < 0)
        {
            throw PlayerException.NegativeValue("Bet cannot be negative value!");
        }

        CurrentBet += betIncrease;
    }
}