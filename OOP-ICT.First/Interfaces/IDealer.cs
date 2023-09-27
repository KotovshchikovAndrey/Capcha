namespace OOP_ICT.Models;

public interface IDealer
{
    Card DealCardFromDeck();
    CardDeck GetCardDeck();
}