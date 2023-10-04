namespace OOP_ICT.Second.Abstractions;

public interface IBank
{
    decimal AddBetToPlayerBill(PlayerBill playerBill, decimal bet);
    decimal SubtractBetFromPlayerBill(PlayerBill playerBill, decimal bet);
    bool CheckIsBalanceSufficientForBet(PlayerBill playerBill, decimal bet);
}