using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class Player
{
    public decimal CurrentBet { get; private set; }
    public PlayerBill PlayerBill { get; }

    public Player(PlayerBill playerBill, decimal currentBet = 0)
    {
        CurrentBet = currentBet;
        PlayerBill = playerBill;
    }
}