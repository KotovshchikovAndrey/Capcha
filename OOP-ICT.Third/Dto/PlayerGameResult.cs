using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Third.Dto;

public class PlayerGameResult
{
    public Player Player { get; }
    public decimal WinAmount { get; set; } = 0;
    public decimal LoseAmount { get; set; } = 0;
    
    public IReadOnlyList<Card> Cards { get; }

    public PlayerGameResult(Player player, IReadOnlyList<Card> cards)
    {
        Player = player;
        Cards = cards;
    }
}