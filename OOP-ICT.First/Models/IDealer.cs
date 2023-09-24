namespace OOP_ICT.Models;

public interface IDealer
{
    IReadOnlyList<ICard> GetDeckOfCards();
}