namespace OOP_ICT.Models;

public interface IDealer
{
    Card DealCardFromDeck();
    IReadOnlyList<Card> GetDeckOfCards();
}