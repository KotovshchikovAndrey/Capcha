namespace OOP_ICT.Models;

public interface IDealer
{
    IReadOnlyList<Card> GetDeckOfCards();
}