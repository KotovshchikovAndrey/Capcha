namespace OOP_ICT.Models;

public interface ICard
{
    CardSuit Suit { get; }
    CardValue Value { get; }
}