namespace OOP_ICT.Third.Abstractions;

public interface ICanPlaceBet
{
    decimal CurrentBet { get; }
    void IncreaseCurrentBet(decimal betIncrease);
}