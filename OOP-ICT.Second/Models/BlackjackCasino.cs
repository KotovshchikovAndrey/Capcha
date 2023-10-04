using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BlackjackCasino
{
    private readonly IBank _bank;
    public BlackjackCasino(IBank bank)
    {
        _bank = bank;
    }

    public void AddWinningAmount(Player player)
    {
        _bank.AddBetToPlayerBill(player.PlayerBill, player.CurrentBet);
    }

    public void SubtractLossAmount(Player player)
    {
        _bank.SubtractBetFromPlayerBill(player.PlayerBill, player.CurrentBet);
    }

    public void AddBlackjackAmount(Player player)
    {
        _bank.AddBetToPlayerBill(player.PlayerBill, player.CurrentBet * (decimal)1.5);
    }
}